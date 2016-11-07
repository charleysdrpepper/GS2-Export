using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs2export {
    static public class Bits //File Storage/data retrieval.
    {
        static public int getInt16(byte[] buffer, int pos) { //(int addr)
            return buffer[pos++] | (buffer[pos] << 8);
        }
        static public int getInt32(byte[] buffer, int pos) { //(int addr)
            return buffer[pos++] | (buffer[pos++] << 8) | buffer[pos++] << 16 | (buffer[pos] << 24);
        }
    }
    class Class1 {
        const int THUMB_TYPE1 = 0x00;
const int THUMB_TYPE2		=0x01;
const int THUMB_TYPE3		=0x02;
const int THUMB_TYPE4		=0x03;
const int THUMB_TYPE5		=0x04;
const int THUMB_TYPE6		=0x05;
const int THUMB_TYPE7		=0x06;
const int THUMB_TYPE8		=0x07;
const int THUMB_TYPE9		=0x08;
const int THUMB_TYPE10	=0x09;
const int THUMB_TYPE11	=0x0A;
const int THUMB_TYPE12	=0x0B;
const int THUMB_TYPE13	=0x0C;
const int THUMB_TYPE14	=0x0D;
const int THUMB_TYPE15	=0x0E;
const int THUMB_TYPE16	=0x0F;
const int THUMB_TYPE17	=0x10;
const int THUMB_TYPE18	=0x11;
const int THUMB_TYPE19	=0x12;

const int THUMB_ARM9			=		0x00000001;
const int THUMB_IMMEDIATE	=			0x00000002;
const int THUMB_REGISTER=				0x00000004;
const int THUMB_D	=					0x00000008;
const int THUMB_S	=					0x00000010;
const int THUMB_POOL=					0x00000020;
const int THUMB_O	=					0x00000040;
const int THUMB_WORD=					0x00000080;
const int THUMB_HALFWORD		=		0x00000100;
const int THUMB_RLIST			=		0x00000200;
const int THUMB_EXCHANGE		=		0x00000400;
const int THUMB_BRANCH			=	0x00000800;
const int THUMB_LONG			=		0x00001000;
const int THUMB_PCR				=	0x00002000;
const int THUMB_DS				=	0x00004000;	// rs = rd
const int THUMB_PCADD			=		0x00008000;
const int THUMB_NEGATIVE_IMMEDIATE=	0x00010000;
        static object[,] ThumbOpcodes = {
//	Name		Mask				Encod	Type		  Len	Flags
	{ "lsl",	"/d0, /s3, /O0",		0x0000,	THUMB_TYPE1,	2,	THUMB_IMMEDIATE },
	{ "lsr",	"/d0, /s3, /O0",		0x0800,	THUMB_TYPE1,	2,	THUMB_IMMEDIATE },
	{ "asr",	"/d0, /s3, /O0",		0x1000,	THUMB_TYPE1,	2,	THUMB_IMMEDIATE },

	{ "add",	"/d0, /s3, /s6",			0x1800,	THUMB_TYPE2,	2,	THUMB_REGISTER },
	{ "sub",	"/d0, /s3, /s6",			0x1A00,	THUMB_TYPE2,	2,	THUMB_REGISTER },
	{ "add",	"/d0, /s3, /i630",		0x1C00,	THUMB_TYPE2,	2,	THUMB_IMMEDIATE },
	{ "sub",	"/d0, /s3, /i630",		0x1E00,	THUMB_TYPE2,	2,	THUMB_IMMEDIATE },
//	{ "mov",	"/d0, /s3",				0x1C00,	THUMB_TYPE2,	2,	0 },

	{ "mov",	"/d8, /i080",		0x2000,	THUMB_TYPE3,	2,	THUMB_IMMEDIATE },
	{ "cmp",	"/d8, /i080",		0x2800,	THUMB_TYPE3,	2,	THUMB_IMMEDIATE },
	{ "add",	"/d8, /i080",		0x3000,	THUMB_TYPE3,	2,	THUMB_IMMEDIATE },
	{ "sub",	"/d8, /i080",		0x3800,	THUMB_TYPE3,	2,	THUMB_IMMEDIATE },

	{ "and",	"/d0, /s3",				0x4000,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "eor",	"/d0, /s3",				0x4040,	THUMB_TYPE4,	2,	THUMB_REGISTER },
//	{ "xor",	"/d0, /s3",				0x4040,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "lsl",	"/d0, /s3",				0x4080,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "lsr",	"/d0, /s3",				0x40C0,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "asr",	"/d0, /s3",				0x4100,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "adc",	"/d0, /s3",				0x4140,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "sbc",	"/d0, /s3",				0x4180,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "ror",	"/d0, /s3",				0x41C0,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "tst",	"/d0, /s3",				0x4200,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "neg",	"/d0, /s3",				0x4240,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "cmp",	"/d0, /s3",				0x4280,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "cmn",	"/d0, /s3",				0x42C0,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "orr",	"/d0, /s3",				0x4300,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "mul",	"/d0, /s3",				0x4340,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "bic",	"/d0, /s3",				0x4380,	THUMB_TYPE4,	2,	THUMB_REGISTER },
	{ "mvn",	"/d0, /s3",				0x43C0,	THUMB_TYPE4,	2,	THUMB_REGISTER },

	{ "add",	"/D, /S",				0x4400,	THUMB_TYPE5,	2,	THUMB_D|THUMB_S },
	{ "cmp",	"/D, /S",				0x4500,	THUMB_TYPE5,	2,	THUMB_D|THUMB_S },
	{ "mov",	"/D, /S",				0x4600,	THUMB_TYPE5,	2,	THUMB_D|THUMB_S },
//	{ "nop",	"",					0x46C0,	THUMB_TYPE5,	2,	0 },
	{ "bx",		"/S",				0x4700,	THUMB_TYPE5,	2,	THUMB_S },
//	{ "blx",	"S",				0x4780,	THUMB_TYPE5,	2,	THUMB_S|THUMB_ARM9 },

//	{ "ldr",	"/d8, [pc, /i080]",	0x4800,	THUMB_TYPE6,	2,	THUMB_IMMEDIATE },
    { "ldr",	"/d8, [/J]",		0x4800,	THUMB_TYPE6,	2,	THUMB_IMMEDIATE|THUMB_PCR },

	{ "str",	"/d0, [/s3, /o6]",			0x5000,	THUMB_TYPE7,	2,	THUMB_D|THUMB_S|THUMB_O },
	{ "strh",	"/d0, [/s3, /o6]",			0x5200,	THUMB_TYPE8,	2,	THUMB_D|THUMB_S|THUMB_O },
    { "strb",	"/d0, [/s3, /o6]",			0x5400,	THUMB_TYPE7,	2,	THUMB_D|THUMB_S|THUMB_O },
	{ "ldsb",	"/d0, [/s3, /o6]",			0x5600,	THUMB_TYPE8,	2,	THUMB_D|THUMB_S|THUMB_O },
    { "ldr",	"/d0, [/s3, /o6]",			0x5800,	THUMB_TYPE7,	2,	THUMB_D|THUMB_S|THUMB_O },
	{ "ldrh",	"/d0, [/s3, /o6]",			0x5A00,	THUMB_TYPE8,	2,	THUMB_D|THUMB_S|THUMB_O },
    { "ldrb",	"/d0, [/s3, /o6]",			0x5C00,	THUMB_TYPE7,	2,	THUMB_D|THUMB_S|THUMB_O },
	{ "ldsh",	"/d0, [/s3, /o6]",			0x5E00,	THUMB_TYPE8,	2,	THUMB_D|THUMB_S|THUMB_O },

	{ "str",	"/d0, [/s3, /O2]",	0x6000,	THUMB_TYPE9,	2,	THUMB_D|THUMB_S|THUMB_IMMEDIATE|THUMB_WORD },
	{ "ldr",	"/d0, [/s3, /O2]",	0x6800,	THUMB_TYPE9,	2,	THUMB_D|THUMB_S|THUMB_IMMEDIATE|THUMB_WORD },
	{ "strb",	"/d0, [/s3, /O0]",	0x7000,	THUMB_TYPE9,	2,	THUMB_D|THUMB_S|THUMB_IMMEDIATE },
	{ "ldrb",	"/d0, [/s3, /O0]",	0x7800,	THUMB_TYPE9,	2,	THUMB_D|THUMB_S|THUMB_IMMEDIATE },
    
	{ "strh",	"/d0, [/s3, /O1]",	0x8000,	THUMB_TYPE10,	2,	THUMB_D|THUMB_S|THUMB_IMMEDIATE|THUMB_HALFWORD },
	{ "ldrh",	"/d0, [/s3, /O1]",	0x8800,	THUMB_TYPE10,	2,	THUMB_D|THUMB_S|THUMB_IMMEDIATE|THUMB_HALFWORD },
    
	{ "str",	"/d8, [sp, /i082]",	0x9000,	THUMB_TYPE11,	2,	THUMB_D|THUMB_IMMEDIATE|THUMB_WORD },
	{ "ldr",	"/d8, [sp, /i082]",	0x9800,	THUMB_TYPE11,	2,	THUMB_D|THUMB_IMMEDIATE|THUMB_WORD },

	{ "add",	"/d8, pc, /i082",	0xA000,	THUMB_TYPE12,	2,	THUMB_D|THUMB_IMMEDIATE|THUMB_WORD },
	//{ "add",	"/d8, =/#i\x20",		0xA000,	THUMB_TYPE12,	2,	THUMB_D|THUMB_IMMEDIATE|THUMB_PCR },
	{ "add",	"/d8, sp, /i082",	0xA800,	THUMB_TYPE12,	2,	THUMB_D|THUMB_IMMEDIATE|THUMB_WORD },

	{ "add",	"sp, /-/i072",		0xB000,	THUMB_TYPE13,	2,	THUMB_IMMEDIATE|THUMB_WORD },

	{ "push",	"{/R1}",	0xB400,	THUMB_TYPE14,	2,	THUMB_RLIST },
	{ "pop",	"{/R2}",	0xBC00,	THUMB_TYPE14,	2,	THUMB_RLIST },

	{ "stmia",	"/d8!, {/R0}",	0xC000,	THUMB_TYPE15,	2,	THUMB_D|THUMB_RLIST },
	{ "ldmia",	"/d8!, {/R0}",	0xC800,	THUMB_TYPE15,	2,	THUMB_D|THUMB_RLIST },

	{ "beq",	"/j",			0xD000,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH },
	{ "bne",	"/j",			0xD100,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bcs",	"/j",			0xD200,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
//	{ "bhs",	"/#I\x08",			0xD200,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bcc",	"/j",			0xD300,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
///	{ "blo",	"/#I\x08",			0xD300,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bmi",	"/j",			0xD400,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bpl",	"/j",			0xD500,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bvs",	"/j",			0xD600,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bvc",	"/j",			0xD700,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bhi",	"/j",			0xD800,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bls",	"/j",			0xD900,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bge",	"/j",			0xDA00,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "blt",	"/j",			0xDB00,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "bgt",	"/j",			0xDC00,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },
	{ "ble",	"/j",			0xDD00,	THUMB_TYPE16,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },

	{ "swi",	"/i080",			0xDF00,	THUMB_TYPE17,	2,	THUMB_IMMEDIATE },
//	{ "bkpt",	"/#i\x08",			0xBE00,	THUMB_TYPE17,	2,	THUMB_IMMEDIATE|THUMB_ARM9 },

	{ "b",		"/j",			0xE000,	THUMB_TYPE18,	2,	THUMB_IMMEDIATE|THUMB_BRANCH  },

	{ "bl",		"/j",			0xF000,	THUMB_TYPE19,	4,	THUMB_IMMEDIATE|THUMB_BRANCH|THUMB_LONG  },
//	{ "blx",	"/#I\x16",			0xF000,	THUMB_TYPE19,	4,	THUMB_IMMEDIATE|THUMB_ARM9|THUMB_EXCHANGE|THUMB_BRANCH|THUMB_LONG },
	{ "blh",		"/i0;1;",			0xF800,	THUMB_TYPE19,	4,	THUMB_IMMEDIATE|THUMB_BRANCH|THUMB_LONG },
//	{ "blx",	"/#I\x16",			0xF800,	THUMB_TYPE19,	4,	THUMB_IMMEDIATE|THUMB_ARM9|THUMB_EXCHANGE|THUMB_BRANCH|THUMB_LONG },

	{ null, null, 0, 0, 0,0}
};
        static String[] r = { "r0", "r1", "r2", "r3", "r4", "r5", "r6", "r7", "r8", "r9", "r10", "r11", "r12", "sp", "lr", "pc" };
        //package gseditor;

        //import java.util.ArrayList;
        //import java.util.List;
        //import java.util.Stack;

        //import javax.swing.JOptionPane;

        /**
         * 
         * @author Tea
         */
        //public class Asm {
        // ldr/add PC relative
        //int awe(int g) {
            
        //}
        static public StringBuilder asmstrs(byte[] rom, int start, int end) {
            StringBuilder str = new StringBuilder(0x8000);
            int bytes = (end - start) + 1;
            int hwords = (bytes >> 1) + 1;
            int words = (bytes >> 2) + 1;
            bool[] isValue = new bool[words];
            bool[] placeLabel = new bool[hwords]; //(e.g. _address)
            int cur = start;
            while (cur < end) {
                int v = Bits.getInt16(rom, cur);
                //cur += 2;
                if (isValue[(cur - start) >> 2]) {
                    cur += 2;
                    //bitspos += 2;
                } else if (v < 0x4800) {
                    if ((v & 0xFF87) == 0x4687) {
                        // v |= (Bits.getInt16(rom, bitspos)<<16);
                        // bitspos -= 2;
                        // v -= (start + 0x8000000);
                        cur = (cur + 2) & -3;
                        int cur2 = cur - start; // (cur+2) & -3;
                        while (true) {
                            int v2 = (int)Bits.getInt32(rom, cur) - start - 0x8000000;

                            if ((0 <= v2) && (v2 < (end - start))) {
                                isValue[cur2 >> 2] = true;
                                placeLabel[v2 >> 1] = true; //isPointed[v2] = true;
                                // tab[v2] = (byte) (tabn + 1);
                            } else {
                                break;
                            }
                            cur += 4;
                            cur2 += 4;
                        }
                        // bitspos -=4;
                        // cur -= 4;
                        //cur -= 2;
                    }
                } else if (v < 0x5000) { // LDR-relative
                    int addr = ((cur + 4) & -3) + ((v & 255) << 2) - start;
                    isValue[addr >> 2] = true;
                    placeLabel[addr >> 1] = true; 

                    int pos1 = cur;
                    cur = start + addr;
                    int v2 = (int)Bits.getInt32(rom, cur) - start - 0x8000000;
                    // if ((v2>>25)==4) {
                    if ((0 <= v2) && (v2 < (end - start))) {
                        placeLabel[v2 >> 1] = true; //isPointed[v2] = true;
                    }
                    cur = pos1;
                    // } else if (v < 0x6000) {
                } else if (v < 0xD000) { } else if (v < 0xE000) { // Cond. Branches
                    if (v < 0xDE00) {
                        int addr = ((cur + ((v << 24) >> 23)) + 4) - start;
                        placeLabel[addr >> 1] = true;
                        /*if (addr < cur) {
                            isBranchedDo[addr >> 1] = true;
                        } else {
                            isBranchedIf[addr >> 1] = true;
                        }
                        /*if (addr < cur) {
                            int posdl = posDo.Count - 1; //.size()
                            while ((posdl >= 0) && (addr <= posDo[posdl])) {
                                posdl -= 1;
                            }
                            posdl += 1;
                            // javax.swing.JOptionPane.showMessageDialog(null,posdl);
                            posDo.Insert(posdl, (addr)); //posDo.add(posdl, addr);
                            posLoop.Insert(posdl, cur); //posLoop.add(posdl, cur);
                            // while (scope[addr >> 1] != 0) {
                            // addr = scope[addr >> 1];
                            // }
                            // scope[addr >> 1] = cur;
                        }*/
                        // if (tab[addr >> 1] == 0) {
                        // tab[addr >> 1] = tabn;
                        // }
                        // tab[addr>>1] = tabn + 1;
                    }
                } else if (v < 0xE800) { // Uncond. Branch
                    int addr = ((cur + ((v << 21) >> 20)) + 4) - start;
                    placeLabel[addr >> 1] = true;
                    /*if (addr < cur) {
                        isBranchedDo[addr >> 1] = true;
                    } else {
                        isBranched[addr >> 1] = true;
                    }
                    /*if (addr < cur) {
                        int posdl = posDo.Count() - 1;
                        while ((posdl >= 0) && (addr <= posDo[posdl])) {
                            posdl -= 1;
                        }
                        posdl += 1;
                        // javax.swing.JOptionPane.showMessageDialog(null,posdl);
                        posDo.Insert(posdl, addr);
                        posLoop.Insert(posdl, cur);
                        // while (scope[addr >> 1] != 0) {
                        // addr = scope[addr >> 1];
                        // }
                        // scope[addr >> 1] = cur;
                    }*/
                } else if (v >= 0xF000) { // Branch Link
                    if (v < 0xF800) {
                        //int addr = ((cur + ((v << 21) >> 9)) + ((Bits.getInt16(rom, cur + 2) << 21) >> 20) + 4) - start;
                        int addr = ((cur + ((v << 21) >> 9)) + ((Bits.getInt16(rom, cur + 2) & 0x7FF) << 1) + 4) - start;
                        if ((0 <= addr) && (addr < (end - start))) {
                            placeLabel[addr >> 1] = true;
                            //isCalled[addr >> 1] = true;
                        }
                        //bitspos += 2;
                        cur += 2;
                        // } else {
                        // int addr = ((cur + ((v << 21) >> 20)) + 4);
                    }
                }
                cur += 2;
            }

            int pos = start;
            while (pos < end) {
                if (placeLabel[(pos - start) >> 1] == true) {
                    //int w = Bits.getInt32(rom, pos);
                    str.AppendLine("_0x" + (0x08000000 | pos).ToString("X8") +":");
                }
                str.Append("        ");
                if (isValue[(pos - start) >> 2] == true) {
                    int w = Bits.getInt32(rom, pos);
                    if (((0x08000000 | start) <= w) && (w < (0x08000000 | end))) {
                        str.AppendLine(".word _0x" + (w & ~1).ToString("X8") + (((w & 1) == 0) ? "" : " | 1")); //Label.
                    } else {
                        str.AppendLine(".word 0x" + w.ToString("X8")); //Value.
                    }
                    pos += 4;
                    continue;
                }
                int v = Bits.getInt16(rom, pos);
                if (v == 0xF800) {
                    str.AppendLine(".halfword 0xF800 ; blh 0x0000"); //Not supported by Armips. :(
                    pos += 2;
                    continue;
                }
                //Find matching opcode.
                int i = 0;
                while (i < (ThumbOpcodes.GetLength(0) - 1)) {
                    if (v < (int)ThumbOpcodes[i + 1, 2]) { break; }
                    i++;
                }
                str.Append((string)ThumbOpcodes[i, 0] + " "); //Append opcode name.

                //List parameters.
                string args = (string)ThumbOpcodes[i, 1];
                if (args == null) { pos += 2; continue; }////return (string)str.ToString(); }
                int j = 0;
                while (j < args.Length) {
                    if (args[j] != '/') {
                        str.Append(args[j++]);
                        continue;
                    }
                    j++;
                    switch (args[j++]) {
                        case 'D':
                            str.Append("r" + (((v >> 4) & 8) |(v & 7)));
                            break;
                        case 'd':
                            str.Append("r" + ((v >> (args[j++] - '0')) & 7));
                            break;
                        case 'S':
                            str.Append("r" + ((v >> 3) & 0xF));
                            break;
                        case 's':
                            str.Append("r" + ((v >> (args[j++] - '0')) & 7));
                            break;
                        case 'n':
                            str.Append("0x" + ((v >> 3) & 0xF).ToString("X2"));
                            break;
                        case 'o':
                            str.Append("r" + ((v >> (args[j++] - '0')) & 7));
                            break;
                        case 'O':
                            str.Append("0x" + (((v >> 6) & 0x1F) << (args[j++] - '0')).ToString("X"));
                            break;
                        //case 'I':
                            //dest += sprintf(dest, "0x%0*X", (Vars.ImmediateBitLen + 3) >> 2, Vars.OriginalImmediate);
                            //encoding += 2;
                            //break;
                        case '-':
                            if ((v & 0x80) != 0) { str.Append("-"); }
                            break;
                        case 'i': //Immediate value
                            str.Append("0x" + ((((v >> (args[j++] - '0')) & ((1 << (args[j++] - '0'))-1)) << (args[j++] - '0')).ToString("X")));
                            break;
                        case 'J': //LDR-relative Jump type
                            int addr = ((pos + 4) & -3) + ((v & 255) << 2);
                            str.Append("_0x" + (0x08000000 | addr).ToString("X8")); //Label.
                            break;
                        case 'j': //Jump type
                            if ((v & 0xF000) == 0xD000) { //B{cond}
                                int jump = pos + ((v << 24) >> 23) + 4;
                                if ((start <= jump) && (jump < end)) {
                                    str.Append("_0x" + (0x08000000 | jump).ToString("X8")); //Label.
                                } else {
                                    str.Append("0x" + (0x08000000 | jump).ToString("X8")); //Value.
                                }
                            }  else if ((v & 0xF800) == 0xE000) { //B
                                int jump = pos + ((v << 21) >> 20) + 4;
                                if ((start <= jump) && (jump < end)) {
                                    str.Append("_0x" + (0x08000000 | jump).ToString("X8")); //Label.
                                } else {
                                    str.Append("0x" + (0x08000000 | jump).ToString("X8")); //Value.
                                }
                            } else if ((v & 0xF800) == 0xF000) { //BL
                                //switch ((int)ThumbOpcodes[i + 1, 3]) {
                                //    case 18: //BL
                                int v2 = Bits.getInt16(rom, pos + 2);
                                //int jump = pos + (((v & 0x7FF) << 12) | ((v2 & 0x7FF) << 1)) + 4;
                                int jump = pos + (((v << 0x15) >> 9) | ((v2 & 0x7FF) << 1)) + 4;
                                if ((start <= jump) && (jump < end)) {
                                    str.Append("_0x" + (0x08000000 | jump).ToString("X8")); //Label.
                                } else {
                                    str.Append("0x" + (0x08000000 | jump).ToString("X8")); //Value.
                                }
                                pos += 2;
                                //        break;
                                //}
                            }
                            break;
                        //case 'r':	// forced register
                            //dest += sprintf(dest, "r%d", *(encoding + 1));
                            //encoding += 2;
                       //     break;
                        case 'R':
                            str.Append(doRlist(v, r));
                            switch (args[j++]) {
                                case '1':
                                    str.Append((((v >> 8) & 1) == 1) ? (((v & 0xFF) == 0) ? "" : ",") + r[14] : "");
                                    break;
                                case '2':
                                    str.Append((((v >> 8) & 1) == 1) ? (((v & 0xFF) == 0) ? "" : ",") + r[15] : "");
                                    break;
                            }
                            //dest += sprintf(dest, "%s", Vars.RlistStr);
                            //encoding += 3;
                            break;
                        //case '/':	// optional
                            //encoding += 2;
                            //j++;
                        //    break;
                        default:
                            str.Append(args[j]);
                            break;
                    }
                    //j++;
                }
                str.AppendLine();
                pos += 2;
            }
            return str;
        }
        static public string asmstrs2(byte[] rom, int start, int end) {
            // int cur = start;
            
            // LDR-relative , Branch , Pointer, and Function flagging
            // byte f[] = new byte[((end-start)>>2)+1];
            // 00 = Clear-code
            // 01 = LDR-relative
            // 02 = Branched flag
            // 04 = Branched flag 2nd
            // 08 = Function called?
            // 10 = Pointer'd
            int bytes = (end - start) + 1;
            int hwords = (bytes >> 1) + 1;
            int words = (bytes >> 2) + 1;
            bool[] isValue = new bool[words];
            bool[] isBranched = new bool[hwords];
            bool[] isBranchedDo = new bool[hwords];
            bool[] isBranchedIf = new bool[hwords];
            // byte tab[] = new byte[hwords];
            bool[] isCalled = new bool[hwords];
            // boolean isFunction[] = new boolean[hwords];
            bool[] isPointed = new bool[bytes];
            // JOptionPane.showMessageDialog(null,isValue[0]);
            int bitspos = start;
            // byte tabn = 0;
            // List<Integer> tabUntil = new ArrayList<Integer>();
            List<int> posDo = new List<int>(100);
            List<int> posLoop = new List<int>(100);
            // int scope[] = new int[hwords]; //do/tab helper
            // int tabscope[] = new int[128]; //tab until address.
            // tab[0] = 1;
            for (int cur = 0; cur < (end - start); cur += 2) {

                // if (tab[cur >> 1] < 1) {
                // tab[cur >> 1] = tab[(cur >> 1) - 1];
                // }

                // String str = "[ ??? ]";

                int v = Bits.getInt16(rom, bitspos);
                bitspos += 2;
                if (isValue[cur >> 2]) {
                    cur += 2;
                    bitspos += 2;
                } else if (v < 0x4800) {
                    if ((v & 0xFF87) == 0x4687) {
                        // v |= (Bits.getInt16(rom, bitspos)<<16);
                        // bitspos -= 2;
                        // v -= (start + 0x8000000);
                        bitspos = (bitspos + 2) & -3;
                        cur = bitspos - start; // (cur+2) & -3;
                        while (true) {
                            int v2 = (int)Bits.getInt32(rom, bitspos) - start - 0x8000000;

                            if ((0 <= v2) && (v2 < (end - start))) {
                                isValue[cur >> 2] = true;
                                isPointed[v2] = true;
                                // tab[v2] = (byte) (tabn + 1);
                            } else {
                                break;
                            }
                            bitspos += 4;
                            cur += 4;
                        }
                        // bitspos -=4;
                        // cur -= 4;
                        cur -= 2;
                    }
                } else if (v < 0x5000) { // LDR-relative
                    int addr = ((cur + 4) & -3) + ((v & 255) << 2);
                    isValue[addr >> 2] = true;

                    int pos = bitspos;
                    bitspos = start + addr;
                    int v2 = (int)Bits.getInt32(rom, bitspos) - start - 0x8000000;
                    // if ((v2>>25)==4) {
                    if ((0 <= v2) && (v2 < (end - start))) {
                        isPointed[v2] = true;
                    }
                    bitspos = pos;
                    // } else if (v < 0x6000) {
                } else if (v < 0xD000) { } else if (v < 0xE000) { // Cond. Branches
                    if (v < 0xDE00) {
                        int addr = ((cur + ((v << 24) >> 23)) + 4);
                        if (addr < cur) {
                            isBranchedDo[addr >> 1] = true;
                        } else {
                            isBranchedIf[addr >> 1] = true;
                        }
                        if (addr < cur) {
                            int posdl = posDo.Count - 1; //.size()
                            while ((posdl >= 0) && (addr <= posDo[posdl])) {
                                posdl -= 1;
                            }
                            posdl += 1;
                            // javax.swing.JOptionPane.showMessageDialog(null,posdl);
                            posDo.Insert(posdl, (addr)); //posDo.add(posdl, addr);
                            posLoop.Insert(posdl, cur); //posLoop.add(posdl, cur);
                            // while (scope[addr >> 1] != 0) {
                            // addr = scope[addr >> 1];
                            // }
                            // scope[addr >> 1] = cur;
                        }
                        // if (tab[addr >> 1] == 0) {
                        // tab[addr >> 1] = tabn;
                        // }
                        // tab[addr>>1] = tabn + 1;
                    }
                } else if (v < 0xE800) { // Uncond. Branch
                    int addr = ((cur + ((v << 21) >> 20)) + 4);
                    if (addr < cur) {
                        isBranchedDo[addr >> 1] = true;
                    } else {
                        isBranched[addr >> 1] = true;
                    }
                    if (addr < cur) {
                        int posdl = posDo.Count() - 1;
                        while ((posdl >= 0) && (addr <= posDo[posdl])) {
                            posdl -= 1;
                        }
                        posdl += 1;
                        // javax.swing.JOptionPane.showMessageDialog(null,posdl);
                        posDo.Insert(posdl, addr);
                        posLoop.Insert(posdl, cur);
                        // while (scope[addr >> 1] != 0) {
                        // addr = scope[addr >> 1];
                        // }
                        // scope[addr >> 1] = cur;
                    }
                } else if (v >= 0xF000) { // Branch Link
                    if (v < 0xF800) {
                        int addr = ((cur + ((v << 21) >> 9)) + ((Bits.getInt16(rom, bitspos) << 21) >> 20) + 4);
                        if ((0 <= addr) && (addr < (end - start))) {
                            isCalled[addr >> 1] = true;
                        }
                        bitspos += 2;
                        cur += 2;
                        // } else {
                        // int addr = ((cur + ((v << 21) >> 20)) + 4);
                    }
                }
            }
            // javax.swing.JOptionPane.showMessageDialog(null,posDo.get(posDo.size()-1));
            // javax.swing.JOptionPane.showMessageDialog(null,posDo.get(posDo.size()));
            // //OUT OF BOUNDS
            // JOptionPane.showMessageDialog(null,isValue[0]);
            String[] inst = { "LSL", "LSR", "ASR", "ADD", "SUB", "ADD", "SUB", "MOV", "CMP", "ADD", "SUB", "AND", "EOR", "LSL", "LSR",
				"ASR", "ADC", "SBC", "ROR", // 9
				"TST", "NEG", "CMP", "CMN", "ORR", "MUL", "BIC", "MVN", // 17
				"ADD", "CMP", "MOV", "BX", "LDR", // 25
				"STR", "STRH", "STRB", "LDSB", "LDR", "LDRH", "LDRB", "LDSH", // 30
				"STR", "LDR", "STRB", "LDRB", "STRH", "LDRH", "STR", "LDR", // 38
				"ADD", "PUSH", "POP", "STMIA", "LDMIA", "BKPT", // 46
				"BEQ", "BNE", "BCS", "BCC", "BMI", "BPL", "BVS", "BVC", // 52
				"BHI", "BLS", "BGE", "BLT", "BGT", "BLE", "SWI", // 60
				"B", "BL", "BLH", "z","z","z","z" // 67
		};
            String[] r = { "R0", "R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8", "R9", "R10", "R11", "R12", "SP", "LR",
				"PC" };
            // byte bo[] = {
            // 11, 11, 11, 9, 9, 9, 9, 11, 11, 11, 11,};

            // int insti = 0;
            // int boi = 0;
            // int type = 0;
            // String strs[] = new String[(end - start) / 2];
            int[] rv = new int[16]; // register values
            byte[] rt = new byte[16]; // register types (Constant/Variable.)
            int[] rm = new int[16]; // register multipliers
            int[] rl = new int[16]; // Register has loaded variable. (Should have
            // number of register for use when moving vars.)
            for (int a = 0; a < 16; a++) {
                rm[a] = 1;
            }
            StringBuilder string1 = new StringBuilder(0x8000);
            // int slen = 0;
            byte binst = 0;
            Stack<int> tabUntil = new Stack<int>();
            int scopeInd = 0;
            // switch (scopeInd)
            // {
            // case 0-2:
            // }
            // tabUntil.
            int[] tForm = { //FF00 = Form, 000F = Shift to Op
					0x000B, 0x1809, 0x200B, 0x4006, //
					0x4408, 0x480B, 0x5009, 0x600B, //
					0x900B, 0xA00C, 0xB008, 0xB10B, //
					0xC00B, 0xD008, 0xDE08, 0xDF08, //
					0xE00B, 0xE80B, 0xF00B, 0xF80B };
            for (int cur = start; cur < end; cur += 2) {
                // for (int boi = 0; boi < bo.length; boi++) {
                // if ((Bits.getInt16(GSEditor.rom, cur) >> bo[boi]) == type) //{
                // continue; };
                // {



                // if ( scopeInd < posDo.size()) {
                // while ( cur < posDo.get(scopeInd)) {
                // scopeInd+=1;
                // }
                while ((scopeInd < posDo.Count()) && ((cur - start) == posDo[scopeInd])) {
                    tabUntil.Push(posLoop[scopeInd]);
                    scopeInd += 1;
                }
                // }

                int straddr = cur;
                String str = "[ ??? ]";
                bitspos = cur;
                int v;
                bool addstr = true;
                if (isValue[(cur - start) >> 2] == true) {
                    // str = Integer.toHexString((int) Bits.getInt32(rom, bitspos));
                    cur += 2;
                    bitspos += 2;
                    // addstr = false;
                } else {
                    v = Bits.getInt16(rom, bitspos);
                    int curc = cur - start;
                    if ((isBranchedDo[curc >> 1] == true) || (isBranchedIf[curc >> 1] == true) || (isPointed[curc] == true)
                            || (isCalled[curc >> 1] == true) || (v >= 0xD000)) {
                        for (int i = 0; i < 16; i++) {
                            rt[i] = 0;
                            rm[i] = 1;
                        }
                    }

                    //Calculate Format and Opcode indexes
                    int f = 0, op = 0;
                    while ((f < 19) && (v >= (tForm[f + 1] & 0xFF00))) {
                        op += (((tForm[f + 1] & 0xFF00) - (tForm[f] & 0xFF00)) >> (tForm[f] & 0xF)); f++;
                    }
                    op += ((v - (tForm[f] & 0xFF00)) >> (tForm[f] & 0xF));

                    //Separate instruction parts to variables
                    int Rd = v & 3, Rs = (v >> 3) & 3, Rb = Rs, Offset = (v >> 6) & 0x1F, Rn = (v >> 6) & 7, nn = Rn, Ro = Rn, Word = v & 0xFF;
                    switch (f) {
                        case 2: Offset = v & 0xFF; Rd = (v >> 8) & 3; break;
                        case 4: Rs = Rs | ((v >> 4) & 8); Rd = Rd | ((v >> 5) & 8); break;
                        case 5:
                        case 8:
                        case 9: Rd = (v >> 8) & 3; break;
                        case 12: Rb = (v >> 8) & 3; break;
                        //case 
                    }

                    //Operation Calculations
                    //int op*2+rt[]
                    switch (op) {
                        case 0: rm[Rd] = rm[Rs] << Offset; rv[Rd] = rv[Rs] << Offset; break;
                        case 1:
                        case 2:
                        case 3: //rv[Rd] =
                            break;
                    }

                    //Thumb Strings ( + High-Level Conversion? )
                    switch (f) {
                        case 0: if (v == 0) { addstr = false; }
                            str = inst[op] + " " + r[Rd] + ", " + r[Rs] + ", " + "#0x" + (Offset).ToString("X");break;
                        case 1: switch ((v >> 10) & 1) {
                                case 0: str = inst[op] + " " + r[Rd] + ", " + r[Rs] + ", " + r[Rn]; break;
                                case 1: str = inst[op] + " " + r[Rd] + ", " + r[Rs] + ", " + "#0x" + (nn).ToString("X"); break;
                            }break;
                        case 2: str = inst[op] + " " + r[Rd] + ", #0x" + (Offset).ToString("X"); break;
                        case 3: str = inst[op] + " " + r[Rd] + ", " + r[Rs]; break;
                        case 4: str = ((((((v >> 8) & 3) < 3) && (((v >> 6) & 3) == 0))
                                || ((((v >> 8) & 3) == 3) && (((v >> 7) & 1) == 1))) ?
                                        "[ ??? ]" : inst[op] + " " + ((((v >> 8) & 3) < 3) ? r[Rd] + ", " : "") + r[Rs]);break;
                        case 5:
                            int pos = bitspos;
                            int addr = ((cur + 4) & -3) + ((v & 255) << 2);
                            bitspos = addr;
                            int ldrval = (int)Bits.getInt32(rom, bitspos);
                            bitspos = pos;
                            str = inst[op] + " " + r[Rd] + "[$" + (addr).ToString("X")
                                // + ", [" + r[15]
                                // + ", #0x" + Integer.toHexString((v & 255) << 2)
                                        + "] (=$" + (ldrval).ToString("X") + ")";break;
                        case 6: str = inst[op] + " " + r[Rd] + ", [" + r[Rb] + ", " + r[Ro] + "]"; break;
                        case 7:
                            int i = ((((v - 0x6000) >> 11) & 7) >> 1);
                            if (i == 0) { i = 3; }; i -= 1;
                            str = inst[op] + " " + r[Rd] + ", [" + r[Rb] + ", #0x" + (Offset << i).ToString("X") + "]";break;
                        case 8: str = inst[op] + " " + r[Rd] + ", [" + r[13] + ", #0x" + ((v & 255) << 2).ToString("X") + "]"; break;
                        case 9: int addr1 = ((cur + 4) & -3) + ((v & 255) << 2);
                            str = inst[op] + " " + r[(v >> 8) & 7] + ", [" + (((v >> 11) & 1) == 0 ? r[15] : r[13]) + ", #0x" + ((v & 255) << 2).ToString("X") + "]"
                                    + (((v >> 11) & 1) == 0 ? " (=$" + (addr1).ToString("X") + ")" : "");break;
                        case 10: str = inst[op] + " " + r[13] + ", " + ((((v >> 7) & 1) == 1) ? "-" : "") + "#0x" + ((v & 127) << 2).ToString("X"); break;
                        case 11:
                            if (((v >> 9) & 3) == 2) {
                                str = inst[op] + " {" + doRlist(v, r) + ((((v >> 8) & 1) == 1) ? (((v & 0xFF) == 0) ? "" : ",") + r[14 + ((v >> 11) & 1)] : "") + "}";
                            }break;
                        case 12: str = inst[op] + " " + r[Rb] + "!, {" + doRlist(v, r) + "}"; break;
                        case 13:
                            int addr2 = ((cur + ((v << 24) >> 23)) + 4);
                            if (addr2 < cur) {
                                // isBranchedDo[addr >> 1] = true;
                                // binst -= 1;
                            } else {
                                if ((tabUntil.Count() == 0) || ((addr2 - start) <= tabUntil.ElementAt(tabUntil.Count() - 1))) {
                                    tabUntil.Push(addr2 - start);
                                    binst += 1;
                                }
                                // isBranchedIf[addr >> 1] = true;
                            }
                            str = inst[op] + " $" + (addr2).ToString("X");break;
                        case 14: str = inst[op]; break;
                        case 15: str = inst[op] + " $" + (v & 255).ToString("X"); break;
                        case 16:
                            int addr3 = ((cur + ((v << 21) >> 20)) + 4);
                            str = inst[op] + " $" + (addr3).ToString("X");break;
                        case 17: str = inst[op]; break;
                        case 18: bitspos += 2;
                            str = inst[op] + " $" + ((cur + ((v << 21) >> 9)) + ((Bits.getInt16(rom, bitspos) << 21) >> 20) + 4).ToString("X");
                            // + Bits.getInt16(GSEditor.rom, cur);
                            // str += Integer.toHexString(((v << 21) >> 20) + 4);
                            cur += 2;break;
                        case 19: str = inst[op] + " $" + ((v << 21) >> 20).ToString("X"); break;
                    } //op 69



                    if (v < 0x2000) {
                        int a = v & 7;
                        int b = (v >> 3) & 7;
                        if (v < 0x1800) {
                            if (v == 0) {
                                addstr = false;
                            }
                            int c = (v >> 6) & 31;
                            // str = inst[(v >> 11) & 3] + " " + r[a] + ", " + r[b]
                            // + ", " + "#0x" + Integer.toHexString(c);

                            if (rt[b] == 1) {
                                switch ((v >> 11) & 3) {
                                    case 0:
                                        rv[a] = rv[b] << c;
                                        break;
                                    case 1:
                                        rv[a] = rv[b] >> c;
                                        break;
                                    case 2:
                                        rv[a] = rv[b] >> c;break;
                                }
                                str += " (=0x" + (rv[a]).ToString("X") + ")";
                            }
                            if (rt[b] == 0) {
                                switch ((v >> 11) & 3) {
                                    case 0:
                                        rm[a] = rm[b] << c;
                                        break;
                                    case 1:
                                        // rm[a] = rm[b] >> c;
                                        break;
                                    case 2:
                                    // rm[a] = rm[b] >> c;
                                        break;
                                }
                                str += " (=*0x" + (rm[a]).ToString("X") + ")";
                            }
                        } else if (v < 0x2000) {
                            int c = (v >> 6) & 7;
                            // str = inst[3 + ((v >> 9) & 1)]
                            // + " "
                            // + r[a]
                            // + ", "
                            // + r[b]
                            // + ", "
                            // + (((v >> 10) & 1) == 1 ? ("#0x" + Integer
                            // .toHexString(c)) : (r[c]));
                            if (rt[b] == 1) {
                                if (((v >> 9) & 1) == 0) {
                                    if (((v >> 10) & 1) == 0) {
                                        rv[a] = rv[b] + rv[c];
                                    } else {
                                        rv[a] = rv[b] - rv[c];
                                    }
                                    if (rt[c] == 1) {
                                        str += " (=0x" + (rv[a]).ToString("X") + ")";
                                        rt[a] = 1;
                                    } else {
                                        rt[a] = 0;
                                    }
                                } else {
                                    if (((v >> 10) & 1) == 0) {
                                        rv[a] = rv[b] + c;
                                    } else {
                                        rv[a] = rv[b] - c;
                                    }
                                    rt[a] = 1;
                                    str += " (=0x" + (rv[a]).ToString("X") + ")";
                                }
                            } else {
                                rt[a] = 0;
                            }
                        }
                    } else if (v < 0x4000) {
                        // str = inst[5 + ((v >> 11) & 3)] + " " + r[(v >> 8) & 7]
                        // + ", #0x" + Integer.toHexString(v & 255);
                        // if (rt[(v>>8)&7] == 1) {
                        switch ((v >> 11) & 3) {
                            case 0:
                                rv[(v >> 8) & 7] = (v & 255);
                                rt[(v >> 8) & 7] = 1;
                                break;
                            case 1:
                                break;
                            case 2:
                                rv[(v >> 8) & 7] += (v & 255);
                                break;
                            case 3:
                                rv[(v >> 8) & 7] -= (v & 255);break;
                        }
                        if ((rt[(v >> 8) & 7] == 1) && (((v >> 11) & 3) >= 2)) {
                            str += " (=0x" + (rv[(v >> 8) & 7]).ToString("X") + ")";
                        }
                        // } else {
                        // rt[(v>>8)&7] = 0;
                        // }
                    } else if (v < 0x4400) {
                        // str = inst[9 + ((v >> 6) & 15)] + " " + r[v & 7] + ", "
                        // + r[(v >> 3) & 7];

                        if ((rt[v & 7] == 1) && (rt[(v >> 3) & 7] == 1)) {
                            str += " (=0xTODO)(=0x" + (0 - rv[(v >> 3) & 7]).ToString("X");
                        }
                        rt[v & 7] = 0;
                    } else if (v < 0x4800) {
                        int a = ((v >> 4) & 8) | (v & 7);
                        int b = (v >> 3) & 15;
                        // str = ((((((v >> 8) & 3) < 3) && (((v >> 6) & 3) == 0))
                        // || ((((v >> 8) & 3) == 3) && (((v >> 7) & 1) == 1))) ?
                        // "[ ??? ]"
                        //
                        // : inst[25 + ((v >> 8) & 3)]
                        // + " "
                        // + ((((v >> 8) & 3) < 3) ? r[a] + ", " : "")
                        // + r[b]);

                        switch ((v >> 8) & 3) {
                            case 0:
                                if ((rt[a] == 1) && (rt[b] == 1)) {
                                    rv[a] += rt[b];
                                    rt[a] = 1;
                                } else {
                                    rt[a] = 0;
                                }
                                break;
                            case 2:
                                if (rt[b] == 1) {
                                    rv[a] = rv[b];
                                    rt[a] = rt[b];
                                } else {
                                    rt[a] = 0;
                                }
                                break;
                            case 3:
                                for (int i = 0; i < 16; i++) {
                                    rt[i] = 0;
                                }break;
                        }
                        if (rt[a] == 1) {
                            str += " (=0x" + (rv[a]).ToString("X") + ")";
                        }
                    } else if (v < 0x5000) {
                        int pos = bitspos;
                        int addr = ((cur + 4) & -3) + ((v & 255) << 2);
                        bitspos = addr;
                        int ldrval = (int)Bits.getInt32(rom, bitspos);
                        bitspos = pos;
                        str = inst[29] + " " + r[(v >> 8) & 7] + " [$" + (addr).ToString("X")
                            // + ", [" + r[15]
                            // + ", #0x" + Integer.toHexString((v & 255) << 2)
                                + "] (=$" + (ldrval).ToString("X") + ")";

                        rv[(v >> 8) & 7] = ldrval;
                        rt[(v >> 8) & 7] = 1;
                    } else if (v < 0x6000) {
                        str = inst[30 + ((v >> 9) & 7)] + " " + r[v & 7] + ", [" + r[(v >> 3) & 7] + ", "
                                + r[(v >> 6) & 7] + "]";

                        if (((v >> 9) & 7) >= 3) {
                            rt[v & 7] = 0;
                        }
                    } else if (v < 0x9000) {
                        int i = ((((v - 0x6000) >> 11) & 7) >> 1);
                        if (i == 0) {
                            i = 3;
                        };
                        i -= 1;
                        str = inst[38 + (((v - 0x6000) >> 11) & 7)] + " " + r[v & 7] + ", [" + r[(v >> 3) & 7] + ", #0x"
                                + (((v >> 6) & 31) << i).ToString("X") + "]";

                        rt[v & 7] = 0; // todo
                    } else if (v < 0xA000) {
                        str = inst[44 + ((v >> 11) & 1)] + " " + r[(v >> 8) & 7] + ", [" + r[13] + ", #0x" + ((v & 255) << 2).ToString("X") + "]";
                        rt[(v >> 8) & 7] = 0; // todo
                    } else if (v < 0xB000) {
                        int addr = ((cur + 4) & -3) + ((v & 255) << 2);
                        str = inst[46] + " " + r[(v >> 8) & 7] + ", [" + (((v >> 11) & 1) == 0 ? r[15] : r[13]) + ", #0x"
                                + ((v & 255) << 2).ToString("X") + "]"
                                + (((v >> 11) & 1) == 0 ? " (=$" + (addr).ToString("X") + ")" : "");

                        if (((v >> 11) & 1) == 0) {
                            rv[(v >> 8) & 7] = addr;
                            rt[(v >> 8) & 7] = 1;
                        } else {
                            rt[(v >> 8) & 7] = 0;
                        }
                    } else if (v < 0xB100) {
                        str = inst[46] + " " + r[13] + ", " + ((((v >> 7) & 1) == 1) ? "-" : "") + "#0x"
                                + ((v & 127) << 2).ToString("X");

                        rt[13] = 0; // todo
                    } else if (v < 0xC000) {// Push/Pop/BKPT
                        if (((v >> 9) & 3) == 2) {
                            str = inst[47 + ((v >> 11) & 1)]
                                    + " {"
                                    + doRlist(v, r)
                                    + ((((v >> 8) & 1) == 1) ? (((v & 0xFF) == 0) ? "" : ",") + r[14 + ((v >> 11) & 1)]
                                            : "") + "}";

                            for (int i = 0; i < 16; i++) { // todo
                                rt[i] = 0;
                            }
                        }
                    } else if (v < 0xD000) {
                        str = inst[49 + ((v >> 11) & 1)] + " " + r[(v >> 8) & 7] + "!, {" + doRlist(v, r) + "}";

                        // if (((v >> 11) & 1) == 0) {
                        // if (rt[(v >> 8) & 7] == 1) {
                        // if ((start <= rv[(v >> 8) & 7])
                        // && (rv[(v >> 8) & 7] < end)) {
                        // for (int i = 0; i < 8; i++) {
                        // if (((v >> i) & 1) == 1) {
                        // int pos = bitspos;
                        // //int addr = ((cur + 4) & -3) + ((v & 255) << 2);
                        // bitspos = rv[(v >> 8) & 7];
                        // int val = (int) Bits.getInt32(rom, bitspos);
                        // bitspos = pos;
                        // rv[i] = val;
                        // //isValue[(rv[(v >> 8) & 7] - start) >> 2] = true;
                        // //TODO: Move to first scan.
                        // rv[(v >> 8) & 7] += 4;
                        // }
                        // }
                        // }
                        // }
                        // }
                        // str += "   ********************";
                    } else if (v < 0xE000) {
                        if (v < 0xDE00) {
                            int addr = ((cur + ((v << 24) >> 23)) + 4);
                            if (addr < cur) {
                                // isBranchedDo[addr >> 1] = true;
                                // binst -= 1;
                            } else {
                                if ((tabUntil.Count() == 0) || ((addr - start) <= tabUntil.ElementAt(tabUntil.Count() - 1))) {
                                    tabUntil.Push(addr - start);
                                    binst += 1;
                                }
                                // isBranchedIf[addr >> 1] = true;
                            }
                            str = inst[52 + ((v >> 8) & 15)] + " $" + (addr).ToString("X");
                            // str += "    " + (addr) + " <=? " +
                            // tabUntil.get(tabUntil.size() - 1);
                        } else if (v >= 0xDF00) {
                            str = inst[66] + " $" + (v & 255).ToString("X");
                        }
                    } else if (v < 0xE800) {
                        int addr = ((cur + ((v << 21) >> 20)) + 4);
                        if (addr < cur) {
                            // isBranchedDo[addr >> 1] = true;
                            // binst -= 1;
                        } else {
                            // if (( 0 > tabUntil.size() - 1) || (addr <=
                            // tabUntil.get(tabUntil.size() - 1))) {
                            // tabUntil.push(addr - start);
                            // }
                            // while (( scopeInd < posDo.size()) && ((cur - start)
                            // == posDo.get(scopeInd))) {
                            // tabUntil.push(posLoop.get(scopeInd));
                            // scopeInd+=1;
                            // }
                            // while (( 0 <= tabUntil.size() - 1) && ((cur - start)
                            // >= tabUntil.get(tabUntil.size() - 1))) {
                            // //while (( scopeInd < posDo.size()) && ((cur - start)
                            // == posDo.get(scopeInd))) {
                            // tabUntil.pop();//(posLoop.get(scopeInd));
                            // //scopeInd-=1;
                            // }
                            // int posdl = posDo.size() - 1;
                            // while ((posdl >= 0) && (addr <= posDo.get(posdl))) {
                            // posdl -= 1;
                            // }
                            // posdl +=1;
                            // posDo.add(posdl, addr);
                            // posLoop.add(posdl, cur);
                            // isBranchedIf[addr >> 1] = true;
                            // slen +=1;
                        }
                        str = inst[67] + " $" + (addr).ToString("X");
                    } else if (v >= 0xF000) { // str="[ ??? ]"
                        if (v < 0xF800) {
                            bitspos += 2;
                            str = inst[68] + " $"
                                    + ((cur + ((v << 21) >> 9)) + ((Bits.getInt16(rom, bitspos) << 21) >> 20) + 4).ToString("X");
                            // + Bits.getInt16(GSEditor.rom, cur);
                            // str += Integer.toHexString(((v << 21) >> 20) + 4);
                            cur += 2;
                        } else {
                            str = inst[69] + " $" + ((v << 21) >> 20).ToString("X");
                        }
                    }

                    // string.append(Integer.toHexString(v) + "  " + str + "\n");
                    // type += 1; //Correct this w/ shift.
                }
                if (addstr == true) {
                    String flags = "  ";
                    if (isBranched[(cur - start) >> 1] == true) {
                        flags = "B^";
                    } else if (isBranchedDo[(cur - start) >> 1] == true) {
                        flags = "Bv";
                        // slen += 1;
                    } else if (isBranchedIf[(cur - start) >> 1] == true) {
                        flags = "B^";
                        // binst+=1;
                        // slen -= 1;
                    } else if (isCalled[(cur - start) >> 1] == true) {
                        flags = "C ";
                    } else if (isPointed[(cur - start)] == true) {
                        flags = "P ";
                    } else if (isPointed[(cur - start) + 1] == true) {
                        flags = "T ";
                    }
                    // if (slen < 0) {
                    // slen = 0;
                    // } // JOptionPane.showMessageDialog(null,"YO"); }
                    // sbinst &= 1;
                    string1.Append(flags + (straddr).ToString("X") + " " + spacing(tabUntil.Count() - binst) + str
                            + "\n");
                    // slen += binst;
                    binst = 0;
                    while ((0 <= tabUntil.Count() - 1) && ((cur - start) >= tabUntil.ElementAt(tabUntil.Count() - 1))) {
                        // while (( scopeInd < posDo.size()) && ((cur - start) ==
                        // posDo.get(scopeInd))) {
                        tabUntil.Pop();// (posLoop.get(scopeInd));
                        // scopeInd-=1;
                    }
                }
                
            }
            // JOptionPane.showMessageDialog(null, "TESTY");
            return string1.ToString();
        }
        /*
        void doThumbString() {
            
            while ((scopeInd < posDo.size()) && ((cur - start) == posDo.get(scopeInd))) {
                tabUntil.push(posLoop.get(scopeInd));
                scopeInd += 1;
            }
            // }

            int straddr = cur;
            String str = "[ ??? ]";
            bitspos = cur;
            int v;
            bool addstr = true;
            if (isValue[(cur - start) >> 2] == true) {
                str = Integer.toHexString((int)Bits.getInt32(rom, bitspos));
                cur += 2;
                bitspos += 2;
                // addstr = false;
            } else {
                v = Bits.getInt16(rom, bitspos);
                int curc = cur - start;
                if ((isBranchedDo[curc >> 1] == true) || (isBranchedIf[curc >> 1] == true) || (isPointed[curc] == true)
                        || (isCalled[curc >> 1] == true) || (v >= 0xD000)) {
                    for (int i = 0; i < 16; i++) {
                        rt[i] = 0;
                        rm[i] = 1;
                    }
                }
                if (v < 0x2000) {
                    int a = v & 7;
                    int b = (v >> 3) & 7;
                    if (v < 0x1800) {
                        if (v == 0) {
                            addstr = false;
                        }
                        int c = (v >> 6) & 31;
                        str = inst[(v >> 11) & 3] + " " + r[a] + ", " + r[b] + ", " + "#0x" + Integer.toHexString(c);

                        if (rt[b] == 1) {
                            switch ((v >> 11) & 3) {
                                case 0:
                                    rv[a] = rv[b] << c;
                                    break;
                                case 1:
                                    rv[a] = rv[b] >> c;
                                    break;
                                case 2:
                                    rv[a] = rv[b] >> c;
                            }
                            str += " (=0x" + Integer.toHexString(rv[a]) + ")";
                        }
                        if (rt[b] == 0) {
                            switch ((v >> 11) & 3) {
                                case 0:
                                    rm[a] = rm[b] << c;
                                    break;
                                case 1:
                                    // rm[a] = rm[b] >> c;
                                    break;
                                case 2:
                                // rm[a] = rm[b] >> c;
                            }
                            str += " (=*0x" + Integer.toHexString(rm[a]) + ")";
                        }
                    } else if (v < 0x2000) {
                        int c = (v >> 6) & 7;
                        str = inst[3 + ((v >> 9) & 1)] + " " + r[a] + ", " + r[b] + ", "
                                + (((v >> 10) & 1) == 1 ? ("#0x" + Integer.toHexString(c)) : (r[c]));
                        if (rt[b] == 1) {
                            if (((v >> 9) & 1) == 0) {
                                if (((v >> 10) & 1) == 0) {
                                    rv[a] = rv[b] + rv[c];
                                } else {
                                    rv[a] = rv[b] - rv[c];
                                }
                                if (rt[c] == 1) {
                                    str += " (=0x" + Integer.toHexString(rv[a]) + ")";
                                    rt[a] = 1;
                                } else {
                                    rt[a] = 0;
                                }
                            } else {
                                if (((v >> 10) & 1) == 0) {
                                    rv[a] = rv[b] + c;
                                } else {
                                    rv[a] = rv[b] - c;
                                }
                                rt[a] = 1;
                                str += " (=0x" + Integer.toHexString(rv[a]) + ")";
                            }
                        } else {
                            rt[a] = 0;
                        }
                    }
                } else if (v < 0x4000) {
                    str = inst[5 + ((v >> 11) & 3)] + " " + r[(v >> 8) & 7] + ", #0x" + Integer.toHexString(v & 255);
                    // if (rt[(v>>8)&7] == 1) {
                    switch ((v >> 11) & 3) {
                        case 0:
                            rv[(v >> 8) & 7] = (v & 255);
                            rt[(v >> 8) & 7] = 1;
                            break;
                        case 1:
                            break;
                        case 2:
                            rv[(v >> 8) & 7] += (v & 255);
                            break;
                        case 3:
                            rv[(v >> 8) & 7] -= (v & 255);
                    }
                    if ((rt[(v >> 8) & 7] == 1) && (((v >> 11) & 3) >= 2)) {
                        str += " (=0x" + Integer.toHexString(rv[(v >> 8) & 7]) + ")";
                    }
                    // } else {
                    // rt[(v>>8)&7] = 0;
                    // }
                } else if (v < 0x4400) {
                    str = inst[9 + ((v >> 6) & 15)] + " " + r[v & 7] + ", " + r[(v >> 3) & 7];

                    if ((rt[v & 7] == 1) && (rt[(v >> 3) & 7] == 1)) {
                        str += " (=0xTODO)(=0x" + Integer.toHexString(0 - rv[(v >> 3) & 7]);
                    }
                    rt[v & 7] = 0;
                } else if (v < 0x4800) {
                    int a = ((v >> 4) & 8) | (v & 7);
                    int b = (v >> 3) & 15;
                    str = ((((((v >> 8) & 3) < 3) && (((v >> 6) & 3) == 0)) || ((((v >> 8) & 3) == 3) && (((v >> 7) & 1) == 1))) ? "[ ??? ]"

                            : inst[25 + ((v >> 8) & 3)] + " " + ((((v >> 8) & 3) < 3) ? r[a] + ", " : "") + r[b]);

                    switch ((v >> 8) & 3) {
                        case 0:
                            if ((rt[a] == 1) && (rt[b] == 1)) {
                                rv[a] += rt[b];
                                rt[a] = 1;
                            } else {
                                rt[a] = 0;
                            }
                            break;
                        case 2:
                            if (rt[b] == 1) {
                                rv[a] = rv[b];
                                rt[a] = rt[b];
                            } else {
                                rt[a] = 0;
                            }
                            break;
                        case 3:
                            for (int i = 0; i < 16; i++) {
                                rt[i] = 0;
                            }
                    }
                    if (rt[a] == 1) {
                        str += " (=0x" + Integer.toHexString(rv[a]) + ")";
                    }
                } else if (v < 0x5000) {
                    int pos = bitspos;
                    int addr = ((cur + 4) & -3) + ((v & 255) << 2);
                    bitspos = addr;
                    int ldrval = (int)Bits.getInt32(rom, bitspos);
                    bitspos = pos;
                    str = inst[29] + " " + r[(v >> 8) & 7] + " [$" + Integer.toHexString(addr)
                        // + ", [" + r[15]
                        // + ", #0x" + Integer.toHexString((v & 255) << 2)
                            + "] (=$" + Integer.toHexString(ldrval) + ")";

                    rv[(v >> 8) & 7] = ldrval;
                    rt[(v >> 8) & 7] = 1;
                } else if (v < 0x6000) {
                    str = inst[30 + ((v >> 9) & 7)] + " " + r[v & 7] + ", [" + r[(v >> 3) & 7] + ", " + r[(v >> 6) & 7]
                            + "]";

                    if (((v >> 9) & 7) >= 3) {
                        rt[v & 7] = 0;
                    }
                } else if (v < 0x9000) {
                    int i = ((((v - 0x6000) >> 11) & 7) >> 1);
                    if (i == 0) {
                        i = 3;
                    };
                    i -= 1;
                    str = inst[38 + (((v - 0x6000) >> 11) & 7)] + " " + r[v & 7] + ", [" + r[(v >> 3) & 7] + ", #0x"
                            + Integer.toHexString(((v >> 6) & 31) << i) + "]";

                    rt[v & 7] = 0; // todo
                } else if (v < 0xA000) {
                    str = inst[44 + ((v >> 11) & 1)] + " " + r[(v >> 8) & 7] + ", [" + r[13] + ", #0x"
                            + Integer.toHexString((v & 255) << 2) + "]";
                    rt[(v >> 8) & 7] = 0; // todo
                } else if (v < 0xB000) {
                    int addr = ((cur + 4) & -3) + ((v & 255) << 2);
                    str = inst[46] + " " + r[(v >> 8) & 7] + ", [" + (((v >> 11) & 1) == 0 ? r[15] : r[13]) + ", #0x"
                            + Integer.toHexString((v & 255) << 2) + "]"
                            + (((v >> 11) & 1) == 0 ? " (=$" + Integer.toHexString(addr) + ")" : "");

                    if (((v >> 11) & 1) == 0) {
                        rv[(v >> 8) & 7] = addr;
                        rt[(v >> 8) & 7] = 1;
                    } else {
                        rt[(v >> 8) & 7] = 0;
                    }
                } else if (v < 0xB100) {
                    str = inst[46] + " " + r[13] + ", " + ((((v >> 7) & 1) == 1) ? "-" : "") + "#0x"
                            + Integer.toHexString((v & 127) << 2);

                    rt[13] = 0; // todo
                } else if (v < 0xC000) {// Push/Pop/BKPT
                    if (((v >> 9) & 3) == 2) {
                        str = inst[47 + ((v >> 11) & 1)] + " {" + doRlist(v, r)
                                + ((((v >> 8) & 1) == 1) ? (((v & 0xFF) == 0) ? "" : ",") + r[14 + ((v >> 11) & 1)] : "")
                                + "}";

                        for (int i = 0; i < 16; i++) { // todo
                            rt[i] = 0;
                        }
                    }
                } else if (v < 0xD000) {
                    str = inst[49 + ((v >> 11) & 1)] + " " + r[(v >> 8) & 7] + "!, {" + doRlist(v, r) + "}";

                    // if (((v >> 11) & 1) == 0) {
                    // if (rt[(v >> 8) & 7] == 1) {
                    // if ((start <= rv[(v >> 8) & 7])
                    // && (rv[(v >> 8) & 7] < end)) {
                    // for (int i = 0; i < 8; i++) {
                    // if (((v >> i) & 1) == 1) {
                    // int pos = bitspos;
                    // //int addr = ((cur + 4) & -3) + ((v & 255) << 2);
                    // bitspos = rv[(v >> 8) & 7];
                    // int val = (int) Bits.getInt32(rom, bitspos);
                    // bitspos = pos;
                    // rv[i] = val;
                    // //isValue[(rv[(v >> 8) & 7] - start) >> 2] = true;
                    // //TODO: Move to first scan.
                    // rv[(v >> 8) & 7] += 4;
                    // }
                    // }
                    // }
                    // }
                    // }
                    // str += "   ********************";
                } else if (v < 0xE000) {
                    if (v < 0xDE00) {
                        int addr = ((cur + ((v << 24) >> 23)) + 4);
                        if (addr < cur) {
                            // isBranchedDo[addr >> 1] = true;
                            // binst -= 1;
                        } else {
                            if ((tabUntil.size() == 0) || ((addr - start) <= tabUntil.get(tabUntil.size() - 1))) {
                                tabUntil.push(addr - start);
                                binst += 1;
                            }
                            // isBranchedIf[addr >> 1] = true;
                        }
                        str = inst[52 + ((v >> 8) & 15)] + " $" + Integer.toHexString(addr);
                        // str += "    " + (addr) + " <=? " +
                        // tabUntil.get(tabUntil.size() - 1);
                    } else if (v >= 0xDF00) {
                        str = inst[66] + " $" + Integer.toHexString(v & 255);
                    }
                } else if (v < 0xE800) {
                    int addr = ((cur + ((v << 21) >> 20)) + 4);
                    if (addr < cur) {
                        // isBranchedDo[addr >> 1] = true;
                        // binst -= 1;
                    } else {
                        // if (( 0 > tabUntil.size() - 1) || (addr <=
                        // tabUntil.get(tabUntil.size() - 1))) {
                        // tabUntil.push(addr - start);
                        // }
                        // while (( scopeInd < posDo.size()) && ((cur - start) ==
                        // posDo.get(scopeInd))) {
                        // tabUntil.push(posLoop.get(scopeInd));
                        // scopeInd+=1;
                        // }
                        // while (( 0 <= tabUntil.size() - 1) && ((cur - start) >=
                        // tabUntil.get(tabUntil.size() - 1))) {
                        // //while (( scopeInd < posDo.size()) && ((cur - start) ==
                        // posDo.get(scopeInd))) {
                        // tabUntil.pop();//(posLoop.get(scopeInd));
                        // //scopeInd-=1;
                        // }
                        // int posdl = posDo.size() - 1;
                        // while ((posdl >= 0) && (addr <= posDo.get(posdl))) {
                        // posdl -= 1;
                        // }
                        // posdl +=1;
                        // posDo.add(posdl, addr);
                        // posLoop.add(posdl, cur);
                        // isBranchedIf[addr >> 1] = true;
                        // slen +=1;
                    }
                    str = inst[67] + " $" + Integer.toHexString(addr);
                } else if (v >= 0xF000) { // str="[ ??? ]"
                    if (v < 0xF800) {
                        bitspos += 2;
                        str = inst[68] + " $"
                                + Integer.toHexString((cur + ((v << 21) >> 9)) + ((Bits.getInt16(rom, bitspos) << 21) >> 20) + 4);
                        // + Bits.getInt16(GSEditor.rom, cur);
                        // str += Integer.toHexString(((v << 21) >> 20) + 4);
                        cur += 2;
                    } else {
                        str = inst[69] + " $" + Integer.toHexString((v << 21) >> 20);
                    }
                }

                // string.append(Integer.toHexString(v) + "  " + str + "\n");
                // type += 1; //Correct this w/ shift.
            }
            if (addstr == true) {
                String flags = "  ";
                if (isBranched[(cur - start) >> 1] == true) {
                    flags = "B^";
                } else if (isBranchedDo[(cur - start) >> 1] == true) {
                    flags = "Bv";
                    // slen += 1;
                } else if (isBranchedIf[(cur - start) >> 1] == true) {
                    flags = "B^";
                    // binst+=1;
                    // slen -= 1;
                } else if (isCalled[(cur - start) >> 1] == true) {
                    flags = "C ";
                } else if (isPointed[(cur - start)] == true) {
                    flags = "P ";
                } else if (isPointed[(cur - start) + 1] == true) {
                    flags = "T ";
                }
                // if (slen < 0) {
                // slen = 0;
                // } // JOptionPane.showMessageDialog(null,"YO"); }
                // sbinst &= 1;
                string.append(flags + Integer.toHexString(straddr) + " " + spacing(tabUntil.size() - binst) + str + "\n");
                // slen += binst;
                binst = 0;
                while ((0 <= tabUntil.size() - 1) && ((cur - start) >= tabUntil.get(tabUntil.size() - 1))) {
                    // while (( scopeInd < posDo.size()) && ((cur - start) ==
                    // posDo.get(scopeInd))) {
                    tabUntil.pop();// (posLoop.get(scopeInd));
                    // scopeInd-=1;
                }
            }
        }
        */
        static String spacing(int len) {
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < len; i++) {
                sb.Append("  ");
            }
            return sb.ToString();
        }
        static String doRlist2(int v) {
            String rlist = "";
            int i = 0;
            if ((v & -1) == 0) {
                while (true) {
                    while (((v & 1) == 0)) { v >>= 1; i++; }
                    if ((v & 1) == 1) {
                        rlist += "r" + i.ToString("");
                        if ((v & 7) == 7) {
                            rlist += "-";
                            v >>= 2; i += 2;
                        }
                        //v>>=1;
                        if ((v & -1) != 0) {
                            rlist += ",";
                        }
                        while ((v & 3) == 3) {
                            v >>= 1; i++;
                        }


                    }
                    if ((v & -1) != 0) { rlist += ","; } else { break; }
                }
            }
            return rlist;
        }
        static String doRlist(int v, String[] r) {
            String rlist = "";
            int num = -1;
            for (int i = 0; i <= 8; i++) {
                if ((i < 8) && ((v >> i) & 1) == 1) {
                    switch (num) {
                        case -1:
                            rlist += r[i];
                            num = 0;
                            break;
                        case 0:
                            rlist += "," + r[i];
                            break;
                    }
                    num += 1;
                } else {
                    if (num == 2) {
                        rlist += "," + r[i - 1];
                    } else if (num > 2) {
                        rlist += "-" + r[i - 1];
                    }
                    if (num > 0) {
                        num = 0;
                    }
                }
            }
            return rlist;
        }
    }
}