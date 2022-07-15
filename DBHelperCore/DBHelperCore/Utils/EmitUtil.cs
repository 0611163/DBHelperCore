using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;

namespace DBUtil
{
    /// <summary>
    /// Emit工具类
    /// </summary>
    public class EmitUtil
    {
        #region EmitSetter
        /// <summary>
        /// EmitSetter
        /// </summary>
        public static Action<T, object> EmitSetter<T>(string propertyName)
        {
            var type = typeof(T);
            var dynamicMethod = new DynamicMethod("EmitCall", null, new[] { type, typeof(object) }, type.Module);
            var iLGenerator = dynamicMethod.GetILGenerator();

            var callMethod = type.GetMethod("set_" + propertyName, BindingFlags.Instance | BindingFlags.IgnoreCase | BindingFlags.Public);
            var parameterInfo = callMethod.GetParameters()[0];
            var local = iLGenerator.DeclareLocal(parameterInfo.ParameterType, true);

            iLGenerator.Emit(OpCodes.Ldarg_1);
            if (parameterInfo.ParameterType.IsValueType)
            {
                iLGenerator.Emit(OpCodes.Unbox_Any, parameterInfo.ParameterType); // 如果是值类型，拆箱
            }
            else
            {
                iLGenerator.Emit(OpCodes.Castclass, parameterInfo.ParameterType); // 如果是引用类型，转换
            }

            iLGenerator.Emit(OpCodes.Stloc, local);
            iLGenerator.Emit(OpCodes.Ldarg_0);
            iLGenerator.Emit(OpCodes.Ldloc, local);

            iLGenerator.EmitCall(OpCodes.Callvirt, callMethod, null);
            iLGenerator.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate(typeof(Action<T, object>)) as Action<T, object>;
        }
        #endregion

    }
}