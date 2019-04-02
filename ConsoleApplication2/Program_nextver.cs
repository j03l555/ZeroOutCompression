using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zero-Out Compression by J03L. Version 3.0.0
            Console.WriteLine("Enter the mode (compress OR decompress)");
            string getMode = Console.ReadLine();
            string getFile = "";
            string[] dKey = new string[0];
            //string[] genKey = new string[0];
            //string getMode = "c"; debug purposes
            if (getMode == "c")
            {
                Console.WriteLine("Enter the path of the file you want to compress.");
                getFile = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Enter the path of the file you want to decompress.");
                getFile = Console.ReadLine();
                Console.WriteLine("Enter the key that was returned after compression.");
                String getKey = Console.ReadLine();
                dKey = getKey.Split('-');
                //Console.WriteLine(dKey[10);
            }
            
            //string getFile = @"c:\a\test3_compressed2.txt"; debug purposes
            Console.WriteLine("Enter the path of the file you want to save to.");
            string saveFile = Console.ReadLine();
            FileStream fs = new FileStream(getFile, FileMode.Open);
            FileStream fs_2 = new FileStream(saveFile, FileMode.OpenOrCreate);
            int hexIn;
            String hex_2;
            String hex_3;
            String hex_4;
            String key1 = "";
            int dStage = 1;
            int hexIn_2;
            int hexIn_3;
            int hexIn_4;
            int saveCount1;
            saveCount1 = 0;
            string hex;

            if (getMode == "c")
            {
                //int saveCount;
                //saveCount = 0;
                for (int i = 0; (hexIn = fs.ReadByte()) != -1; i++)
                {
                    hex = string.Format("{0:X2}", hexIn);
                    //if (hex == hex)
                    //{
                        hexIn_2 = fs.ReadByte();
                        hex_2 = string.Format("{0:X2}", hexIn_2);
                        if (hex_2 == hex)
                        {
                            hexIn_3 = fs.ReadByte();
                            hex_3 = string.Format("{0:X2}", hexIn_3);
                            if (hex_3 == hex)
                            {
                                hexIn_4 = fs.ReadByte();
                                hex_4 = string.Format("{0:X2}", hexIn_4);
                                if (hex_4 == hex)
                                {
                                    //Alot of programs have huge areas of hex 00 (unused data), so for every 4 of hex 00 in a row, we can save 1 byte.
                                    int intValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                                    byte newByte2 = (byte)intValue;
                                    //Byte hex_write_1 = new byte();
                                    fs_2.WriteByte(newByte2);
                                    fs_2.WriteByte(42);
                                    fs_2.WriteByte(52);
                                    saveCount1 = saveCount1 + 1;
                                    hex = "00*4";
                                    key1 = key1 + (fs.Position - 3).ToString()+"-";

                                    //fs.Position = fs.Position - 3;
                            }
                                else
                                {
                                    fs.Position = fs.Position - 3;
                                }
                            }
                            else
                            {
                                fs.Position = fs.Position - 2;
                            }
                        }
                        else
                        {
                            fs.Position = fs.Position - 1;
                        }
                    //}
                    if (hex == "00*4")
                    {
                        //Nothing
                    }
                    else
                    {
                        int intValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                        byte newByte = (byte)intValue;
                        fs_2.WriteByte(newByte);
                        long checkLength1 = fs_2.Length + saveCount1;
                        if (checkLength1 == fs.Length)
                        {
                            //Stop writing. If we don't perform this check and the file ends with hex 00, hex 00, will be written forever after writing all the bytes of the file we are compressing.
                            break;
                        }
                    }
                    //else
                    //{
                    //    fs.Position = fs.Position - 1;
                    //}
                    //Console.WriteLine(hex);
                    Console.Write(hex + " ");



                }
            }else
            {
                //Decompress
                for (int i = 0; (hexIn = fs.ReadByte()) != -1; i++)
                {
                    hex = string.Format("{0:X2}", hexIn);
                    //if (hex == "00")
                    //{
                        hexIn_2 = fs.ReadByte();
                        hex_2 = string.Format("{0:X2}", hexIn_2);
                        if (hex_2 == "2A")
                        {
                            hexIn_3 = fs.ReadByte();
                            hex_3 = string.Format("{0:X2}", hexIn_3);
                            if (hex_3 == "34")
                            {
                                Console.WriteLine(fs_2.Position);
                            Console.WriteLine(dKey[dStage]);
                                if (fs.Position.ToString() == dKey[dStage]) {
                                    int intValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                                    byte newByte3 = (byte)intValue;
                                    fs_2.WriteByte(newByte3);
                                    fs_2.WriteByte(newByte3);
                                    fs_2.WriteByte(newByte3);
                                    fs_2.WriteByte(newByte3);
                                    saveCount1 = saveCount1 + 1;
                                    hex = "00*4";
                                    dStage = dStage + 1;
                                }
                            //hexIn_4 = fs.ReadByte();
                            //hex_4 = string.Format("{0:X2}", hexIn_4);
                            //if (hex_4 == "00")
                            //{
                            //    //Alot of programs have huge areas of hex 00 (unused data), so for every 4 of hex 00 in a row, we can save 1 byte.
                            //    hex = "00*4";
                            //    //Byte hex_write_1 = new byte();
                            //    fs_2.WriteByte(00);
                            //    fs_2.WriteByte(00);
                            //    fs_2.WriteByte(00);
                            //    fs_2
                            //    saveCount1 = saveCount1 + 1;

                            //    //fs.Position = fs.Position - 3;
                            //}
                            //else
                            //{
                            //    fs.Position = fs.Position - 3;
                            //}
                            }
                            else
                            {
                                fs.Position = fs.Position - 2;
                            }
                        }
                        else
                        {
                            fs.Position = fs.Position - 1;
                        }
                    //}
                    if (hex == "00*4")
                    {
                        //Nothing
                    }else
                    {

                        int intValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                        byte newByte = (byte)intValue;
                        fs_2.WriteByte(newByte);
                        long checkLength1 = fs_2.Length - saveCount1;
                        if (checkLength1 == fs.Length)
                        {
                            //Stop writing. If we don't perform this check and the file ends with hex 00, hex 00, will be written forever after writing all the bytes of the file we are compressing.
                            break;
                        }
                    }
                    //else
                    //{
                    //    int intValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                    //    byte newByte = (byte)intValue;
                    //    fs_2.WriteByte(newByte);
                    //    long checkLength1 = fs_2.Length + saveCount1;
                    //    if (checkLength1 == fs.Length)
                    //    {
                    //        //Stop writing. If we don't perform this check and the file ends with hex 00, hex 00, will be written forever after writing all the bytes of the file we are compressing.
                    //        break;
                    //    }
                    //}
                    //else
                    //{
                    //    fs.Position = fs.Position - 1;
                    //}
                    //Console.WriteLine(hex);
                    Console.Write(hex + " ");



                }
            }
            Console.WriteLine("By compressing this file, "+(fs.Length - fs_2.Length).ToString()+" bytes can be saved.");
            Console.WriteLine("Your key is:");
            Console.WriteLine();
            Console.WriteLine(key1);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue. Do NOT just close the program otherwise the compressed result will NOT be saved to disk!");
            Console.ReadKey();
        }
    }
}
