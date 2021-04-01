namespace Rein.ILHookHelperAPI
{
    using System;

    using Mono.Cecil.Cil;

    public readonly struct ConvType
    {
        internal readonly OpCode opcode;

        internal ConvType(OpCode opcode) => this.opcode = opcode;

        public static readonly ConvType I = new(OpCodes.Conv_I);
        public static readonly ConvType Ovf_I = new(OpCodes.Conv_Ovf_I);
        public static readonly ConvType Ovf_I_Un = new(OpCodes.Conv_Ovf_I_Un);

        public static readonly ConvType U = new(OpCodes.Conv_U);
        public static readonly ConvType Ovf_U = new(OpCodes.Conv_Ovf_U);
        public static readonly ConvType Ovf_U_Un = new(OpCodes.Conv_Ovf_U_Un);

        public static readonly ConvType I1 = new(OpCodes.Conv_I1);
        public static readonly ConvType Ovf_I1 = new(OpCodes.Conv_Ovf_I1);
        public static readonly ConvType Ovf_I1_Un = new(OpCodes.Conv_Ovf_I1_Un);

        public static readonly ConvType U1 = new(OpCodes.Conv_U1);
        public static readonly ConvType Ovf_U1 = new(OpCodes.Conv_Ovf_U1);
        public static readonly ConvType Ovf_U1_Un = new(OpCodes.Conv_Ovf_U1_Un);

        public static readonly ConvType I2 = new(OpCodes.Conv_I2);
        public static readonly ConvType Ovf_I2 = new(OpCodes.Conv_Ovf_I2);
        public static readonly ConvType Ovf_I2_Un = new(OpCodes.Conv_Ovf_I2_Un);

        public static readonly ConvType U2 = new(OpCodes.Conv_U2);
        public static readonly ConvType Ovf_U2 = new(OpCodes.Conv_Ovf_U2);
        public static readonly ConvType Ovf_U2_Un = new(OpCodes.Conv_Ovf_U2_Un);

        public static readonly ConvType I4 = new(OpCodes.Conv_I4);
        public static readonly ConvType Ovf_I4 = new(OpCodes.Conv_Ovf_I4);
        public static readonly ConvType Ovf_I4_Un = new(OpCodes.Conv_Ovf_I4_Un);

        public static readonly ConvType U4 = new(OpCodes.Conv_U4);
        public static readonly ConvType Ovf_U4 = new(OpCodes.Conv_Ovf_U4);
        public static readonly ConvType Ovf_U4_Un = new(OpCodes.Conv_Ovf_U4_Un);

        public static readonly ConvType I8 = new(OpCodes.Conv_I8);
        public static readonly ConvType Ovf_I8 = new(OpCodes.Conv_Ovf_I8);
        public static readonly ConvType Ovf_I8_Un = new(OpCodes.Conv_Ovf_I8_Un);

        public static readonly ConvType U8 = new(OpCodes.Conv_U8);
        public static readonly ConvType Ovf_U8 = new(OpCodes.Conv_Ovf_U8);
        public static readonly ConvType Ovf_U8_Un = new(OpCodes.Conv_Ovf_U8_Un);

        public static readonly ConvType R_Un = new(OpCodes.Conv_R_Un);
        public static readonly ConvType R4 = new(OpCodes.Conv_R4);
        public static readonly ConvType R8 = new(OpCodes.Conv_R8);
    }
}
