//AUTHOR: Ismail JH + Wassem Kassoumeh from Arab International University


namespace GOGCoreGeneralHelperLibrary
{
    [System.Serializable]
    public class SDES
    {
        System.Collections.BitArray[,] S_Box1 = new System.Collections.BitArray[4, 4];
        System.Collections.BitArray[,] S_Box2 = new System.Collections.BitArray[4, 4];
        System.Collections.BitArray Master_key;

        public SDES(string _key)
        {
            Master_key = new System.Collections.BitArray(10);
            for (int i = 0; i < _key.Length; i++)
            {
                Master_key[i] = str2bin(_key[i]);
            }

            System.Collections.BitArray b0 = new System.Collections.BitArray(2);
            b0[0] = false;
            b0[1] = false;

            System.Collections.BitArray b1 = new System.Collections.BitArray(2);
            b0[0] = false;
            b0[1] = true;

            System.Collections.BitArray b2 = new System.Collections.BitArray(2);
            b0[0] = true;
            b0[1] = false;

            System.Collections.BitArray b3 = new System.Collections.BitArray(2);
            b0[0] = true;
            b0[1] = true;

            

            S_Box1[0, 0] = b1;
            S_Box1[0, 1] = b0;
            S_Box1[0, 2] = b3;
            S_Box1[0, 3] = b2;

            S_Box1[1, 0] = b3;
            S_Box1[1, 1] = b2;
            S_Box1[1, 2] = b1;
            S_Box1[1, 3] = b0;

            S_Box1[2, 0] = b0;
            S_Box1[2, 1] = b2;
            S_Box1[2, 2] = b1;
            S_Box1[2, 3] = b3;

            S_Box1[3, 0] = b3;
            S_Box1[3, 1] = b1;
            S_Box1[3, 2] = b3;
            S_Box1[3, 3] = b2;
            //---------------------
            S_Box2[0, 0] = b0;
            S_Box2[0, 1] = b1;
            S_Box2[0, 2] = b2;
            S_Box2[0, 3] = b3;

            S_Box2[1, 0] = b2;
            S_Box2[1, 1] = b0;
            S_Box2[1, 2] = b1;
            S_Box2[1, 3] = b3;

            S_Box2[2, 0] = b3;
            S_Box2[2, 1] = b0;
            S_Box2[2, 2] = b1;
            S_Box2[2, 3] = b0;

            S_Box2[3, 0] = b2;
            S_Box2[3, 1] = b1;
            S_Box2[3, 2] = b0;
            S_Box2[3, 3] = b3;
            //---------------------
        }

        public byte[] EncriptString( string sValue )
        {
            byte[ ] output = new byte[ sValue.Length ] ;
            for ( int i = 0 ; i < output.Length ; ++i)
            {
                output[i] = Encrypt( System.Convert.ToByte(sValue[i])) ;
            }
            return output ;
        }

        public byte[] EncriptBinarry(byte[] byaValue)
        {
            byte[] output = new byte[byaValue.Length];
            for (int i = 0; i < output.Length; ++i)
            {
                output[i] = Encrypt( byaValue[i] ) ;
            }
            return output ;
        }

        public string DecriptString(byte[] byaValue)
        {
            string output = new string(' ', byaValue.Length);
            for (int i = 0; i < byaValue.Length; ++i)
            {
                output += System.Convert.ToChar(Decrypt(byaValue[i]));
            }
            return output ;
        }

        public byte[] DecriptBinarry(byte[] byaValue)
        {
            byte[] output = new byte[byaValue.Length];
            for (int i = 0; i < output.Length; ++i)
            {
                output[i] = Decrypt( byaValue[i] ) ;
            }
            return output;
        }

        byte Encrypt(byte block)
        {
            System.Collections.BitArray bits_block = byte2bits(block);
            System.Collections.BitArray[] keys = Generate_Keys();
            return bits2byte(RIP(Fk(Switch(Fk(IP(bits_block), keys[0])), keys[1])));
            //ciphertext = IP-1( fK2 ( SW (fK1 (IP (plaintext)))))
        }

        byte Decrypt(byte block)
        {
            System.Collections.BitArray bits_block = byte2bits(block);
            System.Collections.BitArray[] keys = Generate_Keys();
            return bits2byte(RIP(Fk(Switch(Fk(IP(bits_block), keys[1])), keys[0])));
            //IP-1 ( fK1( SW( fK2( IP(ciphertext)))))
        }

        System.Collections.BitArray byte2bits(byte block)
        {
            string bits = decimal2binstr(block);
            System.Collections.BitArray result = new System.Collections.BitArray(8);
            for (int i = 0; i < bits.Length; i++)
            {
                result[i] = str2bin(bits[i]);
            }
            return result;
        }

        byte bits2byte(System.Collections.BitArray block)
        {
            string result = "";
            for (int i = 0; i < block.Length; i++)
            {
                result += bin2str(block[i]);
            }
            return binstr2decimal(result);
        }

        System.Collections.BitArray[] Generate_Keys()
        {
            System.Collections.BitArray [] keys = new System.Collections.BitArray[2];
            System.Collections.BitArray[] temp = Split_Block(P10(Master_key));
            keys[0] = P8(Circular_left_shift(temp[0], 1), Circular_left_shift(temp[1], 1));
            keys[1] = P8(Circular_left_shift(temp[0], 3), Circular_left_shift(temp[1], 3)); //1 + 2 = 3
            return keys;
        }

        // decimal to binary string
        string decimal2binstr(byte num)
        {
            string ret = "";
            for (int i = 0; i < 8; i++)
            {
                if (num % 2 == 1)
                    ret = "1" + ret;
                else
                    ret = "0" + ret;
                num >>= 1;
            }
            return ret;
        }

        // binary to decimal string
        byte binstr2decimal(string binstr)
        {
            byte ret = 0;
            for (int i = 0; i < binstr.Length; i++)
            {
                ret <<= 1;
                if (binstr[i] == '1')
                    ret++;
            }
            return ret;
        }

        string bin2str(bool input)
        {
            if (input)
                return "1";
            else
                return "0";
        }

         bool str2bin(char bit)
        {
            if (bit == '0')
                return false;
            else if (bit == '1')
                return true;
            else
                throw new System.Exception("Key should be in binary format [0,1]");
        }

        //generates  permated array P10
        System.Collections.BitArray P10(System.Collections.BitArray key)
        {
            //0 1 2 3 4 5 6 7 8 9
            //2 4 1 6 3 9 0 8 7 5
            System.Collections.BitArray permutatedArray = new System.Collections.BitArray(10);

            permutatedArray[0] = key[2];
            permutatedArray[1] = key[4];
            permutatedArray[2] = key[1];
            permutatedArray[3] = key[6];
            permutatedArray[4] = key[3];
            permutatedArray[5] = key[9];
            permutatedArray[6] = key[0];
            permutatedArray[7] = key[8];
            permutatedArray[8] = key[7];
            permutatedArray[9] = key[5];

            return permutatedArray;
        }

        //generates permuted array P8
        System.Collections.BitArray P8(System.Collections.BitArray part1, System.Collections.BitArray part2)
        {
            //0 1 2 3 4 5 6 7
            //5 2 6 3 7 4 9 8
            //6 3 7 4 8 5 10 9
            System.Collections.BitArray permutatedArray = new System.Collections.BitArray(8);

            permutatedArray[0] = part2[0];//5
            permutatedArray[1] = part1[2];
            permutatedArray[2] = part2[1];//6
            permutatedArray[3] = part1[3];
            permutatedArray[4] = part2[2];//7
            permutatedArray[5] = part1[4];
            permutatedArray[6] = part2[4];//9
            permutatedArray[7] = part2[3];//8

            return permutatedArray;
        }

        System.Collections.BitArray P4(System.Collections.BitArray part1, System.Collections.BitArray part2)
        {
            //0 1 2 3
            //2 4 3 1
            //1 3 2 0
            System.Collections.BitArray permutatedArray = new System.Collections.BitArray(4);

            permutatedArray[0] = part1[1];
            permutatedArray[1] = part2[1];//3
            permutatedArray[2] = part2[0];//2
            permutatedArray[3] = part1[0];

            return permutatedArray;
        }

        System.Collections.BitArray EP(System.Collections.BitArray input)
        {
            //0 1 2 3
            //4 1 2 3 2 3 4 1
            //3 0 1 2 1 2 3 0
            System.Collections.BitArray permutatedArray = new System.Collections.BitArray(8);

            permutatedArray[0] = input[3];
            permutatedArray[1] = input[0];
            permutatedArray[2] = input[1];
            permutatedArray[3] = input[2];
            permutatedArray[4] = input[1];
            permutatedArray[5] = input[2];
            permutatedArray[6] = input[3];
            permutatedArray[7] = input[0];

            return permutatedArray;
        }

        //generates permuted text IP
        System.Collections.BitArray IP(System.Collections.BitArray plainText)
        {
            //0 1 2 3 4 5 6 7
            //1 5 2 0 3 7 4 6
            System.Collections.BitArray permutatedArray = new System.Collections.BitArray(8);

            permutatedArray[0] = plainText[1];
            permutatedArray[1] = plainText[5];
            permutatedArray[2] = plainText[2];
            permutatedArray[3] = plainText[0];
            permutatedArray[4] = plainText[3];
            permutatedArray[5] = plainText[7];
            permutatedArray[6] = plainText[4];
            permutatedArray[7] = plainText[6];

            return permutatedArray;
        }

        System.Collections.BitArray RIP(System.Collections.BitArray permutedText)
        {
            //0 1 2 3 4 5 6 7 
            //3 0 2 4 6 1 7 5

            System.Collections.BitArray permutatedArray = new System.Collections.BitArray(8);

            permutatedArray[0] = permutedText[3];
            permutatedArray[1] = permutedText[0];
            permutatedArray[2] = permutedText[2];
            permutatedArray[3] = permutedText[4];
            permutatedArray[4] = permutedText[6];
            permutatedArray[5] = permutedText[1];
            permutatedArray[6] = permutedText[7];
            permutatedArray[7] = permutedText[5];

            return permutatedArray;
        }

        System.Collections.BitArray Circular_left_shift(System.Collections.BitArray a, int bitNumber)
        {
            System.Collections.BitArray shifted = new System.Collections.BitArray(a.Length);
            int index = 0;
            for (int i = bitNumber; index < a.Length; i++)
            {
                shifted[index++] = a[i%a.Length]; 
            }
            return shifted;
        }

        System.Collections.BitArray[] Split_Block(System.Collections.BitArray block)
        {
            System.Collections.BitArray[] splited = new System.Collections.BitArray[2];
            splited[0] = new System.Collections.BitArray(block.Length / 2);
            splited[1] = new System.Collections.BitArray(block.Length / 2);
            int index = 0;

            for (int i = 0; i < block.Length/2; i++)
            {
                splited[0][i] = block[i];
            }
            for (int i = block.Length / 2; i < block.Length; i++)
            {
                splited[1][index++] = block[i];
            }
            return splited;
        }

        System.Collections.BitArray S_Boxes(System.Collections.BitArray input, int no)
        {
            System.Collections.BitArray[,] current_S_Box;

            if (no == 1)
                current_S_Box = S_Box1;
            else
                current_S_Box = S_Box2;

            return current_S_Box[binstr2decimal(bin2str(input[0]) + bin2str(input[3])),
                binstr2decimal(bin2str(input[1]) + bin2str(input[2]))];
        }

        System.Collections.BitArray F(System.Collections.BitArray right, System.Collections.BitArray sk)
        {
            System.Collections.BitArray[] temp = Split_Block(Xor(EP(right), sk));
            return P4(S_Boxes(temp[0], 1), S_Boxes(temp[1], 2));
        }

        System.Collections.BitArray Fk(System.Collections.BitArray IP, System.Collections.BitArray key)
        {
            System.Collections.BitArray[] temp = Split_Block(IP);
            System.Collections.BitArray Left = Xor(temp[0], F(temp[1], key));
            System.Collections.BitArray joined = new System.Collections.BitArray(8);
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                joined[index++] = Left[i];
            }
            for (int i = 0; i < 4; i++)
            {
                joined[index++] = temp[1][i];
            }
            return joined;
        }

        System.Collections.BitArray Switch(System.Collections.BitArray input)
        {
            System.Collections.BitArray switched = new System.Collections.BitArray(8);
            int index = 0;
            for (int i = 4; index < input.Length; i++)
            {
                switched[index++] = input[i%input.Length];
            }
            return switched;
        }

        System.Collections.BitArray Xor(System.Collections.BitArray a, System.Collections.BitArray b)
        {
            return b.Xor(a);
        }
    }
}