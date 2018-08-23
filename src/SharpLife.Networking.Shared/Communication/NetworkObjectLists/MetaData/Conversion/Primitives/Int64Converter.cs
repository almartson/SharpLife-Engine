﻿/***
*
*	Copyright (c) 1996-2001, Valve LLC. All rights reserved.
*	
*	This product contains software technology licensed from Id 
*	Software, Inc. ("Id Technology").  Id Technology (c) 1996 Id Software, Inc. 
*	All Rights Reserved.
*
*   This source code contains proprietary and confidential information of
*   Valve LLC and its suppliers.  Access to this code is restricted to
*   persons who have executed a written SDK license with Valve.  Any access,
*   use or distribution of this code by or to any unlicensed person is illegal.
*
****/

using Google.Protobuf;

namespace SharpLife.Networking.Shared.Communication.NetworkObjectLists.MetaData.Conversion.Primitives
{
    public sealed class Int64Converter : BaseArithmeticConverter<long>
    {
        public static Int64Converter Instance { get; } = new Int64Converter();

        private Int64Converter()
        {
        }

        public override void Write(in long value, CodedOutputStream stream)
        {
            ConversionUtils.AddChangedValue(stream);
            stream.WriteInt64(value);
        }

        public override bool Read(CodedInputStream stream, out long result)
        {
            var changed = stream.ReadBool();

            if (changed)
            {
                result = stream.ReadInt64();
            }
            else
            {
                result = default;
            }

            return changed;
        }
    }
}