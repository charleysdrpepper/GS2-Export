using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Text;

namespace gs2export {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\Users\Tea\Downloads\armips_v07d\test.txt"; // @"c:\temp\MyTest.txt";

            // This text is added only once to the file.
            //if (!File.Exists(path)) {
                // Create a file to write to.
            //}
            if (args.Length <= 0) { properUse(); return; }
            String ext = System.IO.Path.GetExtension(args[0]).ToLower();
            if (ext != ".gba") { properUse(); return; }
            byte[] src = System.IO.File.ReadAllBytes(args[0]);
            //byte[] src2 = File.ReadAllBytes(@"C:\Users\Tea\Downloads\armips_v07d\SLPS_010.57.gba");
            //int check = 0;
            //for (int i = 0xAD000; i < 0xB127C; i++) {
            //    if (src[i] != src2[i]) { check = i; break; }
            //}
            //Console.WriteLine(check.ToString("X"));
            //Console.Read();
            //return;

            //int[] offsets = { 0x0, 0x40, 0x800, 0x840, 0x1000, 0x1040, 0x1800, 0x1840 };
            //int oLen = Math.Min(offsets.Length, (src.Length >> 11) << 1);
            //for (int i = 0; i < oLen; i++) {
            //    byte[] data = convertDump(src, offsets[i]);
            //    byte[] compdata = new byte[data.Length * 2]; //*2 should cover more than worst-case scenario...
            //    int dsize = compress(data, 0, compdata, 0);
            //    Array.Resize(ref compdata, dsize); //Cut away unneeded "00" bytes.
            //    System.IO.File.WriteAllBytes(System.IO.Path.GetDirectoryName(args[0]) + @"\out" + offsets[i].ToString("X4") + ".dmp", compdata);
            //}

            StringBuilder createText = Class1.asmstrs(src, 0x00AD000, 0xB127C);// 0x00AD348);
            int addr = 0xB127C;
            //createText.AppendLine("_0x080B127C:");
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ":");
            createText.AppendLine("        .db "
                + "0x" + src[addr++].ToString("X2")
                + ", 0x" + src[addr++].ToString("X2")
                + ", 0x" + src[addr++].ToString("X2")
               + ", 0x" + src[addr++].ToString("X2")
               + ", 0x" + src[addr++].ToString("X2")
               + ", 0x" + src[addr++].ToString("X2")
               + ", 0x" + src[addr++].ToString("X2")
               + ", 0x" + src[addr++].ToString("X2"));
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; GS1 Event Flags");
            createText.AppendLine("        .dh 0x"
                + getInt16(src, addr).ToString("X2") + ", 0x"
                + getInt16(src, addr + 2).ToString("X2") + ", 0x"
                + getInt16(src, addr + 4).ToString("X2") + ", 0x"
                + getInt16(src, addr + 6).ToString("X2") + ", 0x"
                + getInt16(src, addr + 8).ToString("X2") + ", 0x"
                + getInt16(src, addr + 10).ToString("X2"));
            addr += 12;
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; GS1 Djinn Rarities");
            while (addr < 0xB12C8) {
                createText.AppendLine("        .dh 0x"
                    + getInt16(src, addr).ToString("X2") + ", 0x"
                    + getInt16(src, addr + 2).ToString("X2") + ", 0x"
                    + getInt16(src, addr + 4).ToString("X2") + ", 0x"
                    + getInt16(src, addr + 6).ToString("X2") + ", 0x"
                    + getInt16(src, addr + 8).ToString("X2") + ", 0x"
                    + getInt16(src, addr + 10).ToString("X2") + ", 0x"
                    + getInt16(src, addr + 12).ToString("X2"));
                addr += 14;
            }
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; EXP Rates");
            for (int i = 0; i <8; i++) {
                createText.AppendLine("; PC" + i.ToString());
                createText.Append("        .dw ");
                int j = 0;
                while (true) {
                    createText.Append("0x" + getInt32(src, addr).ToString("X8"));
                    addr += 4;
                    if (++j >= 99) { break; }
                    if (j % 10 == 0) {
                        createText.AppendLine();
                        createText.Append("        .dw ");
                        continue;
                    }
                    createText.Append(", ");
                }
                createText.AppendLine();
            }
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Unused?");
            createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8"));
            addr += 4;
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Unknown - Other than being placed at [02002338], possibly unused?");
            for (int i = 0; i < 4; i++) {
                createText.Append("        .db ");
                int j = 0;
                while (true) {
                    createText.Append("0x" + src[addr].ToString("X2"));
                    addr += 1;
                    if (++j >= 5) { break; }
                    createText.Append(", ");
                }
                createText.AppendLine();
            }
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Artifact Slots");
            createText.Append("        .dh ");
            int itm = 0;
            while (true) {
                createText.Append("0x" + getInt16(src, addr).ToString("X4"));
                addr += 2;
                //if (++itm >= 99) { break; }
                if (addr >= 0xB2340) { break; }
                if ((++itm & 0xF) == 0) {
                    createText.AppendLine();
                    createText.Append("        .dh ");
                    continue;
                }
                createText.Append(", ");
            }
            createText.AppendLine();
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ":");
            createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8")
               + ", 0x" + getInt32(src, addr + 4).ToString("X8")
               + ", 0x" + getInt32(src, addr + 8).ToString("X8")
               + ", 0x" + getInt32(src, addr + 12).ToString("X8")
               + ", 0x" + getInt32(src, addr + 16).ToString("X8")
               + ", 0x" + getInt32(src, addr + 20).ToString("X8")
               + ", 0x" + getInt32(src, addr + 24).ToString("X8")
               + ", 0x" + getInt32(src, addr + 28).ToString("X8")
               + ", 0x" + getInt32(src, addr + 32).ToString("X8"));
            addr += 36;
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Items");
            while (addr < 0xB7C14) {
                createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 4).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 8).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 12).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 16).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 20).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 24).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 28).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 32).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 36).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 40).ToString("X8"));
                addr += 44;
            }
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Abilities");
            while (addr < 0xB9E7C) {
                createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 4).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 8).ToString("X8"));
                addr += 12;
            }
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Enemy Stats");
            while (addr < 0xC0F4C) {
                createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 4).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 8).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 12).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 16).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 20).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 24).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 28).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 32).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 36).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 40).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 44).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 48).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 52).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 56).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 60).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 64).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 68).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 72).ToString("X8"));
                addr += 76;
            }
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Party Stats");
            int pc = 0;
            while (addr < 0xC14EC) {
                createText.AppendLine("; PC" + pc++);
                createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 4).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 8).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 12).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 16).ToString("X8"));
                createText.AppendLine("        .dw 0x" + getInt32(src, addr + 20).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 24).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 28).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 32).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 36).ToString("X8"));
                createText.AppendLine("        .dw 0x" + getInt32(src, addr + 40).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 44).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 48).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 52).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 56).ToString("X8"));
                createText.AppendLine("        .dw 0x" + getInt32(src, addr + 60).ToString("X8")
                + ", 0x" + getInt32(src, addr + 64).ToString("X8")
                + ", 0x" + getInt32(src, addr + 68).ToString("X8")
                + ", 0x" + getInt32(src, addr + 72).ToString("X8")
                + ", 0x" + getInt32(src, addr + 76).ToString("X8"));
                addr += 80;
                createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 4).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 8).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 12).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 16).ToString("X8"));
                createText.AppendLine("        .dw 0x" + getInt32(src, addr + 20).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 24).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 28).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 32).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 36).ToString("X8"));
                createText.AppendLine("        .dw 0x" + getInt32(src, addr + 40).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 44).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 48).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 52).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 56).ToString("X8"));
                createText.AppendLine("        .dw 0x" + getInt32(src, addr + 60).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 64).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 68).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 72).ToString("X8")
                    + ", 0x" + getInt32(src, addr + 76).ToString("X8"));
                addr += 80;
                createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8")
    + ", 0x" + getInt32(src, addr + 4).ToString("X8")
    + ", 0x" + getInt32(src, addr + 8).ToString("X8")
    + ", 0x" + getInt32(src, addr + 12).ToString("X8")
    + ", 0x" + getInt32(src, addr + 16).ToString("X8"));
                addr += 20;
            }
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Summons");
            createText.Append("        .db ");
            while (true) {
                createText.Append("0x" + src[addr].ToString("X2"));
                addr += 1;
                if (addr >= 0xC150C) { break; }
                createText.Append(", ");
            }
            createText.AppendLine();
            createText.AppendLine("_0x" + (0x08000000 | addr).ToString("X8") + ": ; Summon Data");


            while (addr < 0xC6F68) {
                createText.AppendLine("        .dw 0x" + getInt32(src, addr).ToString("X8"));
                addr += 4;
            }
            File.WriteAllText(path, createText.ToString());
            Console.WriteLine("End");
            Console.Read();
        }
        static public int getInt16(byte[] buffer, int pos) { //(int addr)
            return buffer[pos++] | (buffer[pos] << 8);
        }
        static public int getInt32(byte[] buffer, int pos) { //(int addr)
            return buffer[pos++] | (buffer[pos++] << 8) | buffer[pos++] << 16 | (buffer[pos] << 24);
        }
        static void properUse() {
            //string str = "8t";
            //int i = 0;
            //if ((str[i] >= '0') && (str[i] <= '9')) {
            //    Console.WriteLine(str[i] - '1');
            //} else {
            //}
            Console.WriteLine(hex2thumb(0x00FF));
            Console.WriteLine("Drag a a GS2 (U) GBA file on the app to extract the contents.");
            Console.WriteLine("(Only supports extracting Party Mechanics at the moment.)");
            Console.Read();
        }

        static string[] inst = {
                            "LSL R0,R3,O",
                            "LSR R0,R3,O",
                            "ASR R0,R3,O",
                            "ADD R0,R3,R6",
                            "SUB R0,R3,R6",
                            "ADD R0,R3,N",
                            "SUB R0,R3,N",
                            "MOV R8,B",
                            "CMP R8,B",
                            "ADD R8,B",
                            "SUB R8,B",
                            "AND R0,R3",
                            "EOR R0,R3",
                            "LSL R0,R3",
                            "LSR R0,R3",
                            "ASR R0,R3",
                            "ADC R0,R3",
                            "SBC R0,R3",
                            "ROR R0,R3",
                            "TST R0,R3",
                            "NEG R0,R3",
                            "CMP R0,R3",
                            "CMN R0,R3",
                            "ORR R0,R3",
                            "MUL R0,R3",
                            "BIC R0,R3",
                            "MVN R0,R3",
                            "ADD RR",
                            "CMP RR",
                            "MOV RR",
                            "BX RS", //?
                            "LDR R8,W",
                            "STR R0,[R3,R6]",
                            "STRH R0,[R3,R6]",
                            "STRB R0,[R3,R6]",
                            "LDSB R0,[R3,R6]",
                            "LDR R0,[R3,R6]",
                            "LDRH R0,[R3,R6]",
                            "LDRB R0,[R3,R6]",
                            "LDSH R0,[R3,R6]",
                            "STR R0,[R3,W]",
                            "LDR R0,[R3,W]",
                            "STRB R0,[R3,B]",
                            "LDRB R0,[R3,B]",
                            "STRH R0,[R3,H]",
                            "LDRH R0,[R3,H]",
                            "STR R8,[S,W]",
                            "LDR R8,[S,W]",
                            "ADD R8,P,W",
                            "ADD R8,S,W",
                            "ADD S,W",
                            "ADD S,-W",
                            "PUSH RLL",
                            "POP RLP",
                            "STMIA RL",
                            "LDMIA RL",
                            "BKPT",
                            "BEQ H",
                            "BNE H",
                            "BCS H",
                            "BCC H",
                            "BMI H",
                            "BPL H",
                            "BVS H",
                            "BVC H",
                            "BHI H",
                            "BLS H",
                            "BGE H",
                            "BLT H",
                            "BGT H",
                            "BLE H",
                            "SWI",
                            "B H",
                            "BL H",
                            "BLH H"
                        };
        static int[] tForm = { //FF00 = Form, 000F = Shift to Op
                          0x000B, 0x1809, 0x200B, 0x4006, //
                          0x4408, 0x480B, 0x5009, 0x600B, //
                          0x900B, 0xA00C, 0xB008, 0xB10B, //
                          0xC00B, 0xD008, 0xDE08, 0xDF08, //
                          0xE00B, 0xE80B, 0xF00B, 0xF80B
                      };
        static string hex2thumb(int hex) { //Should leave off address/label?
            //Calculate Format and Opcode indexes
            int f = 0, op = 0;
            while ((f < 19) && (hex >= (tForm[f + 1] & 0xFF00))) {
                op += (((tForm[f + 1] & 0xFF00) - (tForm[f] & 0xFF00)) >> (tForm[f] & 0xF)); f++;
            }
            op += ((hex - (tForm[f] & 0xFF00)) >> (tForm[f] & 0xF));
            
            string str = inst[op];
            string str2 = "";
            int i = 0;
            while (i < str.Length - 1) { //Instruction name
                str2 += str[i];
                if (str[i++] == ' ') { break; } 
                //str2 += str[i++];
            }
            //i++; //Skip space.
            while (i < str.Length-1) { //Instruction arguments
                switch (str[i++]) {
                    case 'R':
                        str2 += 'R';
                        if ((str[i] >= '0') && (str[i] <= '9')) {
                            str2 += (hex >> (str[i] - '0')) & 7;
                        }
                        if (str[i] == 'R') { //Hi-registers stuff

                        }
                        i++;
                        break;
                    case ' ':
                        break;
                    case ',':
                        str2 += ", ";
                        //i++;
                        break;
                }
                //i++;
                //str = str[i].ToString();
            }
            return str2;
        }
    }
}
