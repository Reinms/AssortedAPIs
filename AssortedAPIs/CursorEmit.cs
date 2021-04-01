namespace Rein.ILHookHelperAPI
{
    using System;
    using System.Reflection;

    using Mono.Cecil.Cil;

    using MonoMod.Cil;

    public static partial class CursorExtensions
    {
        public static ILCursor? OP_Add(this ILCursor? cursor) => cursor?.Emit(OpCodes.Add);
        public static ILCursor? OP_Add_Ovf(this ILCursor? cursor, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Add_Ovf_Un : OpCodes.Add_Ovf);
        public static ILCursor? OP_And(this ILCursor? cursor) => cursor?.Emit(OpCodes.And);
        public static ILCursor? OP_Arglist(this ILCursor? cursor) => cursor?.Emit(OpCodes.Arglist);
        public static ILCursor? OP_Branch_Eq(this ILCursor? cursor, ILLabel target) => cursor?.Emit(OpCodes.Beq, target);
        public static ILCursor? OP_Branch_Ge(this ILCursor? cursor, ILLabel target, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Bge_Un : OpCodes.Bge_Un, target);
        public static ILCursor? OP_Branch_Gt(this ILCursor? cursor, ILLabel target, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Bgt_Un : OpCodes.Bgt_Un, target);
        public static ILCursor? OP_Branch_Le(this ILCursor? cursor, ILLabel target, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Ble_Un : OpCodes.Ble_Un, target);
        public static ILCursor? OP_Branch_Lt(this ILCursor? cursor, ILLabel target, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Blt_Un : OpCodes.Blt_Un, target);
        public static ILCursor? OP_Branch_Ne(this ILCursor? cursor, ILLabel target) => cursor?.Emit(OpCodes.Bne_Un, target);
        public static ILCursor? OP_Box<T>(this ILCursor? cursor) where T : struct => cursor?.OP_Box(typeof(T));
        public static ILCursor? OP_Box(this ILCursor? cursor, Type type) => cursor?.OP_Box(type);
        public static ILCursor? OP_Branch(this ILCursor? cursor, ILLabel label) => cursor?.Emit(OpCodes.Br, label);
        public static ILCursor? OP_Breakpoint(this ILCursor? cursor) => cursor?.Emit(OpCodes.Break);
        public static ILCursor? OP_Branch_False(this ILCursor? cursor, ILLabel target) => cursor?.Emit(OpCodes.Brfalse, target);
        public static ILCursor? OP_Branch_True(this ILCursor? cursor, ILLabel target) => cursor?.Emit(OpCodes.Brtrue, target);
        public static ILCursor? OP_Call<TDelegate>(this ILCursor? cursor, TDelegate method) where TDelegate : Delegate
        {
            cursor?.EmitDelegate<TDelegate>(method);
            return cursor;
        }
        public static ILCursor? OP_New(this ILCursor? cursor, ConstructorInfo constructor) => cursor?.Emit(OpCodes.Newobj, constructor);
        public static ILCursor? OP_StLocal(this ILCursor? cursor, Int32 index) => cursor?.Emit(OpCodes.Stloc, index);
        public static ILCursor? OP_LdLocal(this ILCursor? cursor, Int32 index) => index switch
        {
            0 => cursor?.Emit(OpCodes.Ldloc_0),
            1 => cursor?.Emit(OpCodes.Ldloc_1),
            2 => cursor?.Emit(OpCodes.Ldloc_2),
            3 => cursor?.Emit(OpCodes.Ldloc_3),
            Int32 i when i >= Byte.MinValue && i <= Byte.MaxValue => cursor?.Emit(OpCodes.Ldloc_S, (Byte)index),
            _ => cursor?.Emit(OpCodes.Ldloc, index),
        };
        public static ILCursor? OP_LdLocal_Adr(this ILCursor? cursor, Int32 index) => index switch
        {
            Int32 i when i >= Byte.MinValue && i <= Byte.MaxValue => cursor?.Emit(OpCodes.Ldloca_S, (Byte)index),
            _ => cursor?.Emit(OpCodes.Ldloca, index),
        };
        public static ILCursor? OP_LdField(this ILCursor? cursor, FieldInfo field) => cursor?.Emit(OpCodes.Ldfld, field);
        public static ILCursor? OP_Call(this ILCursor? cursor, MethodInfo method, Boolean tail = false) => tail ? cursor?.Emit(OpCodes.Tail).Emit(OpCodes.Call).Emit(OpCodes.Ret) : cursor?.Emit(OpCodes.Call, method);
        public static ILCursor? OP_CallVirt(this ILCursor? cursor, MethodInfo method, Boolean tail = false) => tail ? cursor?.Emit(OpCodes.Tail).Emit(OpCodes.Callvirt).Emit(OpCodes.Ret) : cursor?.Emit(OpCodes.Callvirt, method);
        public static ILCursor? OP_CallVirt_Constrained(this ILCursor? cursor, MethodInfo method, Type type, Boolean tail = false) => cursor?.Emit(OpCodes.Constrained, type).OP_CallVirt(method, tail);
        public static ILCursor? OP_CallVirt_Constrained<T>(this ILCursor? cursor, MethodInfo method, Boolean tail = false) => cursor?.OP_CallVirt_Constrained(method, typeof(T), tail);
        public static ILCursor? OP_Cast(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Castclass, type);
        public static ILCursor? OP_Cast<T>(this ILCursor? cursor) => cursor?.OP_Cast(typeof(T));
        public static ILCursor? OP_Cmp_Eq(this ILCursor? cursor) => cursor?.Emit(OpCodes.Ceq);
        public static ILCursor? OP_Cmp_Gt(this ILCursor? cursor, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Cgt_Un : OpCodes.Cgt);
        public static ILCursor? OP_IsFinite(this ILCursor? cursor) => cursor?.Emit(OpCodes.Ckfinite);
        public static ILCursor? OP_Cmp_Lt(this ILCursor? cursor, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Clt_Un : OpCodes.Clt);
        public static ILCursor? OP_Conv(this ILCursor? cursor, ConvType conv) => cursor?.Emit(conv.opcode);
        public static ILCursor? OP_CopyBlock(this ILCursor? cursor, Boolean vol = false) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Cpblk);
        public static ILCursor? OP_CopyObj(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Cpobj, type);
        public static ILCursor? OP_CopyObj<T>(this ILCursor? cursor) where T : struct => cursor?.OP_CopyObj(typeof(T));
        public static ILCursor? OP_Div(this ILCursor? cursor, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Div : OpCodes.Div_Un);
        public static ILCursor? OP_Dup(this ILCursor? cursor) => cursor?.Emit(OpCodes.Dup);
        public static ILCursor? OP_EndFilter(this ILCursor? cursor) => cursor?.Emit(OpCodes.Endfilter);
        public static ILCursor? OP_EndFinally(this ILCursor? cursor) => cursor?.Emit(OpCodes.Endfinally);
        public static ILCursor? OP_InitBlock(this ILCursor? cursor, Boolean vol = false) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Initblk);
        public static ILCursor? OP_InitObj(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Initobj, type);
        public static ILCursor? OP_InitObj<T>(this ILCursor? cursor) => cursor?.OP_InitObj(typeof(T));
        public static ILCursor? OP_Is(this ILCursor? cursor, Type t) => cursor?.Emit(OpCodes.Isinst, t);
        public static ILCursor? OP_Is<T>(this ILCursor? cursor) where T : class => cursor?.OP_Is(typeof(T));
        public static ILCursor? OP_Jump(this ILCursor? cursor, MethodInfo target) => cursor?.Emit(OpCodes.Jmp, target);
        public static ILCursor? OP_LdArg(this ILCursor? cursor, UInt16 index) => index switch
        {
            0 => cursor?.Emit(OpCodes.Ldarg_0),
            1 => cursor?.Emit(OpCodes.Ldarg_1),
            2 => cursor?.Emit(OpCodes.Ldarg_2),
            3 => cursor?.Emit(OpCodes.Ldarg_3),
            UInt16 i when i >= Byte.MinValue && i <= Byte.MaxValue => cursor?.Emit(OpCodes.Ldarg_S, (Byte)index),
            _ => cursor?.Emit(OpCodes.Ldarg, index),
        };
        public static ILCursor? OP_LdArg_Adr(this ILCursor? cursor, UInt16 index) => index switch
        {
            UInt16 i when i >= Byte.MinValue && i <= Byte.MaxValue => cursor?.Emit(OpCodes.Ldarga_S, (Byte)index),
            _ => cursor?.Emit(OpCodes.Ldarga, index),
        };
        public static ILCursor? OP_LdConst(this ILCursor? cursor, String value) => cursor?.Emit(OpCodes.Ldstr, value);
        public static ILCursor? OP_LdConst(this ILCursor? cursor, Int32 value) => value switch
        {
            0 => cursor?.Emit(OpCodes.Ldc_I4_0),
            1 => cursor?.Emit(OpCodes.Ldc_I4_1),
            2 => cursor?.Emit(OpCodes.Ldc_I4_2),
            3 => cursor?.Emit(OpCodes.Ldc_I4_3),
            4 => cursor?.Emit(OpCodes.Ldc_I4_4),
            5 => cursor?.Emit(OpCodes.Ldc_I4_5),
            6 => cursor?.Emit(OpCodes.Ldc_I4_6),
            7 => cursor?.Emit(OpCodes.Ldc_I4_7),
            8 => cursor?.Emit(OpCodes.Ldc_I4_8),
            -1 => cursor?.Emit(OpCodes.Ldc_I4_M1),
            Int32 i when i >= SByte.MinValue && i <= SByte.MaxValue => cursor?.Emit(OpCodes.Ldc_I4_S, (SByte)i),
            _ => cursor?.Emit(OpCodes.Ldc_I4, value),
        };
        public static ILCursor? OP_LdConst(this ILCursor? cursor, Int64 value) => cursor?.Emit(OpCodes.Ldc_I8, value);
        public static ILCursor? OP_LdConst(this ILCursor? cursor, Single value) => cursor?.Emit(OpCodes.Ldc_R4, value);
        public static ILCursor? OP_LdConst(this ILCursor? cursor, Double value) => cursor?.Emit(OpCodes.Ldc_R8, value);
        public static ILCursor? OP_LdElem(this ILCursor? cursor, Type type) => type switch
        {
            Type t when t == typeof(IntPtr) => cursor?.Emit(OpCodes.Ldelem_I),
            Type t when t == typeof(SByte) => cursor?.Emit(OpCodes.Ldelem_I1),
            Type t when t == typeof(Int16) => cursor?.Emit(OpCodes.Ldelem_I2),
            Type t when t == typeof(Int32) => cursor?.Emit(OpCodes.Ldelem_I4),
            Type t when t == typeof(Int64) => cursor?.Emit(OpCodes.Ldelem_I8),
            Type t when t == typeof(Single) => cursor?.Emit(OpCodes.Ldelem_R4),
            Type t when t == typeof(Double) => cursor?.Emit(OpCodes.Ldelem_R8),
            Type t when t == typeof(Byte) => cursor?.Emit(OpCodes.Ldelem_U1),
            Type t when t == typeof(UInt16) => cursor?.Emit(OpCodes.Ldelem_U2),
            Type t when t == typeof(UInt32) => cursor?.Emit(OpCodes.Ldelem_U4),
            Type t when t == typeof(Object) => cursor?.Emit(OpCodes.Ldelem_Ref),
            _ => cursor?.Emit(OpCodes.Ldelem_Any, type),
        };
        public static ILCursor? OP_LdElem<T>(this ILCursor? cursor) => cursor?.OP_LdElem(typeof(T));
        public static ILCursor? OP_LdElem_Adr(this ILCursor? cursor, Boolean readOnly = false) => (readOnly ? cursor?.Emit(OpCodes.Readonly) : cursor)?.Emit(OpCodes.Ldelema);
        public static ILCursor? OP_LdField(this ILCursor? cursor, FieldInfo field, Boolean vol = false) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldfld, field);
        public static ILCursor? OP_LdField_Adr(this ILCursor? cursor, FieldInfo field) => cursor?.Emit(OpCodes.Ldflda, field);
        public static ILCursor? OP_LdFtn(this ILCursor? cursor, MethodInfo method) => cursor?.Emit(OpCodes.Ldftn, method);
        public static ILCursor? OP_LdIndirect(this ILCursor? cursor, Type type, Boolean vol = false) => type switch
        {
            Type t when t == typeof(IntPtr) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_I),
            Type t when t == typeof(SByte) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_I1),
            Type t when t == typeof(Int16) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_I2),
            Type t when t == typeof(Int32) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_I4),
            Type t when t == typeof(Int64) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_I8),
            Type t when t == typeof(Single) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_R4),
            Type t when t == typeof(Double) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_R8),
            Type t when t == typeof(Byte) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_U1),
            Type t when t == typeof(UInt16) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_U2),
            Type t when t == typeof(UInt32) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_U4),
            Type t when t == typeof(Object) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldind_Ref),
            _ => throw new ArgumentException(),
        };
        public static ILCursor? OP_LdIndirect<T>(this ILCursor? cursor, Boolean vol = false) => cursor?.OP_LdIndirect(typeof(T), vol);
        public static ILCursor? OP_LdLength(this ILCursor? cursor) => cursor?.Emit(OpCodes.Ldlen);
        public static ILCursor? OP_LdLocal(this ILCursor? cursor, UInt16 index) => index switch
        {
            0 => cursor?.Emit(OpCodes.Ldloc_0),
            1 => cursor?.Emit(OpCodes.Ldloc_1),
            2 => cursor?.Emit(OpCodes.Ldloc_2),
            3 => cursor?.Emit(OpCodes.Ldloc_3),
            UInt16 i when i >= Byte.MinValue && i <= Byte.MaxValue => cursor?.Emit(OpCodes.Ldloc_S, (Byte)i),
            _ => cursor?.Emit(OpCodes.Ldloc, index),
        };
        public static ILCursor? OP_LdLocal_Adr(this ILCursor? cursor, UInt16 index) => index switch
        {
            UInt16 i when i >= Byte.MinValue && i <= Byte.MaxValue => cursor?.Emit(OpCodes.Ldloca_S, (Byte)i),
            _ => cursor?.Emit(OpCodes.Ldloca, index),
        };
        public static ILCursor? OP_LdNull(this ILCursor? cursor) => cursor?.Emit(OpCodes.Ldnull);
        public static ILCursor? OP_LdObj(this ILCursor? cursor, Type type, Boolean vol = false) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Ldobj, type);
        public static ILCursor? OP_LdObj<T>(this ILCursor? cursor, Boolean vol = false) where T : struct => cursor?.OP_LdObj(typeof(T), vol);
        public static ILCursor? OP_LdSField(this ILCursor? cursor, FieldInfo field) => cursor?.Emit(OpCodes.Ldsfld, field);
        public static ILCursor? OP_LdSField_Adr(this ILCursor? cursor, FieldInfo field) => cursor?.Emit(OpCodes.Ldsflda, field);
        public static ILCursor? OP_LdToken(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Ldtoken, type);
        public static ILCursor? OP_LdToken(this ILCursor? cursor, FieldInfo field) => cursor?.Emit(OpCodes.Ldtoken, field);
        public static ILCursor? OP_LdToken(this ILCursor? cursor, MethodInfo method) => cursor?.Emit(OpCodes.Ldtoken, method);
        public static ILCursor? OP_LdToken<T>(this ILCursor? cursor) => cursor?.Emit(OpCodes.Ldtoken, typeof(T));
        public static ILCursor? OP_LdVirtFtn(this ILCursor? cursor, MethodInfo method) => cursor?.Emit(OpCodes.Ldvirtftn, method);
        public static ILCursor? OP_Leave(this ILCursor? cursor, ILLabel target) => cursor?.Emit(OpCodes.Leave, target);
        public static ILCursor? OP_AllocLocal(this ILCursor? cursor) => cursor?.Emit(OpCodes.Localloc);
        public static ILCursor? OP_MkRefAny(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Mkrefany, type);
        public static ILCursor? OP_MkRefAny<T>(this ILCursor? cursor) => cursor?.OP_MkRefAny(typeof(T));
        public static ILCursor? OP_Mul(this ILCursor? cursor) => cursor?.Emit(OpCodes.Mul);
        public static ILCursor? OP_Mul_Ovf(this ILCursor? cursor, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Mul_Ovf_Un : OpCodes.Mul_Ovf);
        public static ILCursor? OP_Negate(this ILCursor? cursor) => cursor?.Emit(OpCodes.Neg);
        public static ILCursor? OP_NewArray(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Newarr, type);
        public static ILCursor? OP_NewArray<T>(this ILCursor? cursor) => cursor?.OP_NewArray(typeof(T));
        public static ILCursor? OP_NewObj(this ILCursor? cursor, ConstructorInfo ctor) => cursor?.Emit(OpCodes.Newobj, ctor);
        public static ILCursor? OP_NoOp(this ILCursor? cursor) => cursor?.Emit(OpCodes.Nop);
        public static ILCursor? OP_Not(this ILCursor? cursor) => cursor?.Emit(OpCodes.Not);
        public static ILCursor? OP_Or(this ILCursor? cursor) => cursor?.Emit(OpCodes.Or);
        public static ILCursor? OP_Pop(this ILCursor? cursor) => cursor?.Emit(OpCodes.Pop);
        public static ILCursor? OP_RefAnyType(this ILCursor? cursor) => cursor?.Emit(OpCodes.Refanytype);
        public static ILCursor? OP_RefAnyVal(this ILCursor? cursor) => cursor?.Emit(OpCodes.Refanyval);
        public static ILCursor? OP_Mod(this ILCursor? cursor, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Rem_Un : OpCodes.Rem);
        public static ILCursor? OP_Return(this ILCursor? cursor) => cursor?.Emit(OpCodes.Ret);
        public static ILCursor? OP_ReThrow(this ILCursor? cursor) => cursor?.Emit(OpCodes.Rethrow);
        public static ILCursor? OP_Shift_L(this ILCursor? cursor) => cursor?.Emit(OpCodes.Shl);
        public static ILCursor? OP_Shift_R(this ILCursor? cursor, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Shr_Un : OpCodes.Shr);
        public static ILCursor? OP_SizeOf(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Sizeof, type);
        public static ILCursor? OP_SizeOf<T>(this ILCursor? cursor) => cursor?.OP_SizeOf(typeof(T));
        public static ILCursor? OP_StArg(this ILCursor? cursor, UInt16 index) => index switch
        {
            UInt16 i when i >= Byte.MinValue && i <= Byte.MaxValue => cursor?.Emit(OpCodes.Starg_S, (Byte)index),
            _ => cursor?.Emit(OpCodes.Starg, index),
        };
        public static ILCursor? OP_StElem(this ILCursor? cursor, Type type) => type switch
        {
            Type t when t == typeof(IntPtr) => cursor?.Emit(OpCodes.Stelem_I),
            Type t when t == typeof(SByte) => cursor?.Emit(OpCodes.Stelem_I1),
            Type t when t == typeof(Int16) => cursor?.Emit(OpCodes.Stelem_I2),
            Type t when t == typeof(Int32) => cursor?.Emit(OpCodes.Stelem_I4),
            Type t when t == typeof(Int64) => cursor?.Emit(OpCodes.Stelem_I8),
            Type t when t == typeof(Single) => cursor?.Emit(OpCodes.Stelem_R4),
            Type t when t == typeof(Double) => cursor?.Emit(OpCodes.Stelem_R8),
            Type t when t == typeof(Object) => cursor?.Emit(OpCodes.Stelem_Ref),
            _ => cursor?.Emit(OpCodes.Stelem_Any, type),
        };
        public static ILCursor? OP_StElem<T>(this ILCursor? cursor) => cursor?.OP_StElem(typeof(T));
        public static ILCursor? OP_StField(this ILCursor? cursor, FieldInfo field, Boolean vol = false) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor).OP_StField(field);
        public static ILCursor? OP_StIndirect(this ILCursor? cursor, Type type, Boolean vol = false) => type switch
        {
            Type t when t == typeof(IntPtr) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stind_I),
            Type t when t == typeof(SByte) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stind_I1),
            Type t when t == typeof(Int16) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stind_I2),
            Type t when t == typeof(Int32) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stind_I4),
            Type t when t == typeof(Int64) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stind_I8),
            Type t when t == typeof(Single) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stind_R4),
            Type t when t == typeof(Double) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stind_R8),
            Type t when t == typeof(Object) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stind_Ref),
            _ => throw new ArgumentException(),
        };
        public static ILCursor? OP_StIndirect<T>(this ILCursor? cursor, Boolean vol = false) => cursor?.OP_StIndirect(typeof(T), vol);
        public static ILCursor? OP_StLocal(this ILCursor? cursor, UInt16 index) => index switch
        {
            0 => cursor?.Emit(OpCodes.Stloc_0),
            1 => cursor?.Emit(OpCodes.Stloc_1),
            2 => cursor?.Emit(OpCodes.Stloc_2),
            3 => cursor?.Emit(OpCodes.Stloc_3),
            UInt16 i when i >= Byte.MinValue && i <= Byte.MaxValue => cursor?.Emit(OpCodes.Stloc_S, (Byte)i),
            _ => cursor?.Emit(OpCodes.Stloc, index),
        };
        public static ILCursor? OP_StObj(this ILCursor? cursor, Type type, Boolean vol = false) => (vol ? cursor?.Emit(OpCodes.Volatile) : cursor)?.Emit(OpCodes.Stobj, type);
        public static ILCursor? OP_StObj<T>(this ILCursor? cursor, Boolean vol = false) where T : struct => cursor?.OP_StObj(typeof(T), vol);
        public static ILCursor? OP_StSField(this ILCursor? cursor, FieldInfo field) => cursor?.Emit(OpCodes.Stsfld, field);
        public static ILCursor? OP_Sub(this ILCursor? cursor) => cursor?.Emit(OpCodes.Sub);
        public static ILCursor? OP_Sub_Ovf(this ILCursor? cursor, Boolean unsigned = false) => cursor?.Emit(unsigned ? OpCodes.Sub_Ovf_Un : OpCodes.Sub_Ovf);
        public static ILCursor? OP_Switch(this ILCursor? cursor, params ILLabel[] targets) => cursor?.Emit(OpCodes.Switch, targets);
        public static ILCursor? OP_Throw(this ILCursor? cursor) => cursor?.Emit(OpCodes.Throw);
        public static ILCursor? OP_Unbox(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Unbox, type);
        public static ILCursor? OP_Unbox<T>(this ILCursor? cursor) where T : struct => cursor?.OP_Unbox(typeof(T));
        public static ILCursor? OP_Unbox_Any(this ILCursor? cursor, Type type) => cursor?.Emit(OpCodes.Unbox_Any, type);
        public static ILCursor? OP_Unbox_Any<T>(this ILCursor? cursor) => cursor?.Emit(OpCodes.Unbox_Any, typeof(T));
        public static ILCursor? OP_Xor(this ILCursor? cursor) => cursor?.Emit(OpCodes.Xor);
    }
}
