using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fsys
{
    class myFileSystem
    {
        private byte[] RootDir;
        private byte[] myFAT;
        private byte[][] clasters;
        string disk;
        public myFileSystem(string disk)
        {
            this.disk = disk;
            RootDir = new byte[90];
            myFAT = new byte[16];
            clasters = new byte[16][];
            for (int i = 0; i < 16; i++)
            {
                this.clasters[i] = new byte[32];
            }
            this.Refresh();
        }
        public int convert(double a)
        {
            int b = Convert.ToInt32(a);
            if (a > b) b++;
            return b;
        }
        public void Save()
        {
            byte[] newData = new byte[618];
            for (int i = 0; i < 90; i++)
            {
                newData[i] = this.RootDir[i];
            }
            for (int i = 90; i < 106; i++)
            {
                newData[i] = this.myFAT[i - 90];
            }
            int it = 106;

            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < 32; k++)
                {
                    newData[it] = this.clasters[j][k];
                    it++;

                }
            }

            File.WriteAllBytes(disk, newData);
        }
        public void Refresh()
        {
            byte[] data = File.ReadAllBytes(disk);
            for (int i = 0; i < 90; i++)
            {
                this.RootDir[i] = data[i];
            }
            for (int i = 90; i < 106; i++)
            {
                this.myFAT[i - 90] = data[i];
            }
            int it = 106;
            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < 32; k++)
                {
                    this.clasters[j][k] = data[it];
                    it++;
                }
            }

        }
        public void Formatting()
        {
            for (int i = 0; i < 16; i++)
            {
                this.myFAT[i] = 255;
            }
            for (int i = 0; i < 90; i++)
            {
                this.RootDir[i] = 0;
            }
            this.Save();
        }
        public int CountFreeClasters(int clasters)
        {
            int FreeClasters = 0;
            bool flag = false;
            for (int i = 0; i < 16; i++)
            {
                if (myFAT[i] == 255)
                {
                    FreeClasters++;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (myFAT[i] > 200)
                    {
                        FreeClasters++;
                    }
                }
            }
            return FreeClasters;
        }
        public int NextFreeClaster()
        {
            int FirstClaster = 0;
            bool flag = false;
            for (int i = 0; i < 16; i++)
            {
                if (myFAT[i] == 255)
                {
                    FirstClaster = i;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (myFAT[i] > 200)
                    {
                        FirstClaster = i;
                        flag = true;
                        break;
                    }
                }
            }
            return FirstClaster;
        }
        public void CleanClaster(int claster)
        {
            for (int i = 0; i < 32; i++)
            {
                clasters[claster][i] = 0;
            }
        }
        public void NewFile(string name, string content)
        {
            int size = this.convert((double)content.Length / 32);
            int FirstClaster = NextFreeClaster();
            char[] ChName = name.ToCharArray();
            for (int i = 0; i < 10; i++)
            {
                int a = i * 9;
                if (RootDir[a] == 0)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        RootDir[a + j] = Convert.ToByte(ChName[j]);
                    }
                    RootDir[a + 7] = Convert.ToByte(size);
                    RootDir[a + 8] = Convert.ToByte(FirstClaster);
                    break;
                }
            }
            int it = 0;
            int clast = FirstClaster;
            int num = 0;
            int CurClaster = FirstClaster;
            char[] ContentChar = content.ToCharArray();
            this.CleanClaster(FirstClaster);
            while (it < content.Length)
            {
                clasters[clast][num] = Convert.ToByte(ContentChar[it]);
                num++;
                it++;
                if (num == 32)
                {
                    num = 0;
                    myFAT[CurClaster] = 129;
                    clast = NextFreeClaster();
                    myFAT[CurClaster] = Convert.ToByte(clast);
                    clast = NextFreeClaster();
                    CurClaster = clast;
                    this.CleanClaster(clast);
                }
            }
            myFAT[clast] = 129;
            this.Save();

        }
        public string Read(string name)
        {
            int claster = 0;
            int size = 0;
            for (int i = 0; i < 10; i++)
            {
                int a = i * 9;
                if (RootDir[a] != 0 && RootDir[a] != 152)
                {
                    string str = Encoding.UTF8.GetString([RootDir[a], RootDir[a + 1], RootDir[a + 2], RootDir[a + 3], RootDir[a + 4], RootDir[a + 5], RootDir[a + 6]]);
                    if (str == name)
                    {
                        size = RootDir[a + 7];
                        claster = RootDir[a + 8];
                        break;
                    }
                }

            }
            string txt = "";
            for (int i = 0; i < size; i++)
            {
                txt += Encoding.UTF8.GetString(clasters[claster]);
                claster = myFAT[claster];
            }
            return txt;
        }
        public void Delete(string name)
        {
            int claster = 0;
            int size = 0;
            for (int i = 0; i < 10; i++)
            {
                int a = i * 9;
                if (RootDir[a] != 0 && RootDir[a] != 152)
                {
                    string str = Encoding.UTF8.GetString([RootDir[a], RootDir[a + 1], RootDir[a + 2], RootDir[a + 3], RootDir[a + 4], RootDir[a + 5], RootDir[a + 6]]);
                    if (str == name)
                    {
                        size = RootDir[a + 7];
                        claster = RootDir[a + 8];
                        RootDir[a] = 152;
                        break;
                    }
                }

            }
            int NextClaster;
            for (int i = 0; i < size; i++)
            {
                NextClaster = myFAT[claster];
                myFAT[claster] = (byte)(256 - myFAT[claster]);
                claster = NextClaster;
            }
            this.Save();
        }
        public bool CanBeRecovered(string name)
        {
            int claster = 0;
            int size = 0;
            bool flag = false;
            for (int i = 0; i < 10; i++)
            {
                int a = i * 9;
                if (RootDir[a] == 152)
                {
                    string str = Encoding.UTF8.GetString([RootDir[a + 1], RootDir[a + 2], RootDir[a + 3], RootDir[a + 4], RootDir[a + 5], RootDir[a + 6]]);
                    if (str == name)
                    {
                        //RootDir[a] = 82;
                        size = RootDir[a + 7];
                        claster = RootDir[a + 8];
                        flag = true;
                        break;
                    }
                }

            }
            int NextClaster;
            for (int i = 0; i < size; i++)
            {
                NextClaster = myFAT[claster];
                if(NextClaster <200 )
                {
                    if (NextClaster != 127)
                    {
                        flag = false;
                        break;
                    }
                }
                //myFAT[claster] = (byte)(256 - myFAT[claster]);
                claster = 256-NextClaster;
            }
            return flag;
        }
        public void Recovery(string name)
        {
            int claster = 0;
            int size = 0;
            for (int i = 0; i < 10; i++)
            {
                int a = i * 9;
                if (RootDir[a] == 152)
                {
                    string str = Encoding.UTF8.GetString([RootDir[a + 1], RootDir[a + 2], RootDir[a + 3], RootDir[a + 4], RootDir[a + 5], RootDir[a + 6]]);
                    if (str == name)
                    {
                        RootDir[a] = 82;
                        size = RootDir[a + 7];
                        claster = RootDir[a + 8];
                        break;
                    }
                }

            }
          
            for (int i = 0; i < size; i++)
            {
                myFAT[claster] = (byte)(256 - myFAT[claster]);
                claster = myFAT[claster];
            }
            this.Save();
        }
        public List<string> Display()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                int a = i * 9;
                if (RootDir[a] != 0 && RootDir[a] != 152)
                {
                    string str = Encoding.UTF8.GetString([RootDir[a], RootDir[a + 1], RootDir[a + 2], RootDir[a + 3], RootDir[a + 4], RootDir[a + 5], RootDir[a + 6]]);
                    list.Add(str);
                }

            }
            return list;

        }
        public List<string> ReDisp()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                int a = i * 9;
                if (RootDir[a] == 152)
                {
                    string str = Encoding.UTF8.GetString([ RootDir[a + 1], RootDir[a + 2], RootDir[a + 3], RootDir[a + 4], RootDir[a + 5], RootDir[a + 6]]);
                    list.Add(str);
                }

            }
            return list;
        }
    public string ReadHex()
        {
            string hex= BitConverter.ToString(RootDir);
            hex+= BitConverter.ToString(myFAT);
            for(int i = 0;i < 16;i++)
            {
            hex+= BitConverter.ToString(clasters[i]);
            }
            return hex;
        }
    public string ReadChar()
        {
            for(int i=0;i<RootDir.Length;i++)
            {
                if (RootDir[i] ==0)
                {
                    RootDir[i] = 42;    
                }
            }
            string Char = Encoding.Default.GetString(RootDir);
            for (int i = 0; i < myFAT.Length; i++)
            {
                if (myFAT[i] == 0)
                {
                    myFAT[i] = 42;
                }
            }
            Char += Encoding.Default.GetString(myFAT);
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (clasters[i][j] == 0)
                    {
                        clasters[i][j] = 42;
                    }
                }
                Char += Encoding.Default.GetString(clasters[i]);
            }
            this.Refresh();
            return Char;
        }
    public int FreeClasters()
        {
            int count = 0;
            for (int i = 0; i < 16; i++)
            {
                if (myFAT[i] >200 || myFAT[i]==127)
                {
                    count++;
                }
            }
            return count;
        }
    }
    

}
