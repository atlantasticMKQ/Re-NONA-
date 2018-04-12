using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKQ2
{
    enum Types
    {
        And,
        Or,
        Nand,
        Nor,
        Not
    }
    static class Ports
    {
        public static bool[] portsData = new bool[byte.MaxValue];
    }
    class Tools
    {
        public static int toolsNumber = 0;
        Types type;
        int inputNumber;
        int outputNumber;
        int[] inputPort;
        int[] outputPort;
        int toolnumber;
        public Tools(Types _type)
        {
            type = _type;
            switch (type)
            {
                case Types.And:
                    inputNumber = 2;
                    outputNumber = 1;
                    break;
                case Types.Or:
                    inputNumber = 2;
                    outputNumber = 1;
                    break;
                case Types.Nand:
                    inputNumber = 2;
                    outputNumber = 1;
                    break;
                case Types.Nor:
                    inputNumber = 2;
                    outputNumber = 1;
                    break;
                case Types.Not:
                    inputNumber = 1;
                    outputNumber = 1;
                    break;
            }
            inputPort = new int[inputNumber];
            outputPort = new int[outputNumber];
            for (int i = 0; i < inputNumber; i++)
            {
                Console.WriteLine("请输入{0}元件输入端{1}所接入端口的编号", type, i );
                inputPort[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < outputNumber; i++)
            {
                Console.WriteLine("请输入{0}元件输出端{1}所接入端口的编号", type, i );
                outputPort[i] = Convert.ToInt32(Console.ReadLine());
            }
            toolnumber = toolsNumber;
            toolsNumber++;
        }
        public void Check()
        {
            Console.WriteLine("这是被创建的第{0}个元件,元件类型为{1}",toolnumber,type);
            for (int i = 0; i < inputNumber; i++)
            {
                Console.WriteLine("输入端{0}所接入的端口号为{1}", i ,inputPort[i]);
                Console.WriteLine("该端口的状态为{0}",Ports.portsData[inputPort[i]]);
            }
            for (int i = 0; i < outputNumber; i++)
            {
                Console.WriteLine("输出端{0}所接入的端口号为{1}", i, outputPort[i]);
                Console.WriteLine("该端口的状态为{0}", Ports.portsData[outputPort[i]]);
            }
        }
    }
    
    class Program
    {
        static int InputControl()
        {
            Restart:
            Console.WriteLine("请输入指令,目前支持的指令有: new,check,");
            switch (Console.ReadLine())
            {
                case "new":
                    Console.WriteLine("目前可供创建的类型:And,Or,Nand,Nor,Not");
                    Console.WriteLine("请输入您想创建的类型");
                    switch (Console.ReadLine())
                    {
                        case "And":
                            return 10000;
                        case "Or":
                            return 10001;
                        case "Nand":
                            return 10002;
                        case "Nor":
                            return 10003;
                        case "Not":
                            return 10004;
                        default:
                            Console.WriteLine("您输入的命令尚未定义");
                            break;
                    }
                    break;
                case "check":
                    return 10010;
                default:
                    Console.WriteLine("您输入的命令尚未定义");
                    break;

            }
            goto Restart;
        }
        static void Maker()
        {
            //bool ifMakerEnd = false;
            //Console.WriteLine("下面您将创建元件");
            //do
            //{
            //    Console.WriteLine("目前可供创建的类型:And,Or,Nand,Nor,Not");
            //    Console.WriteLine("请输入您想创建的类型\"0,1,2,3,4\"");
            //    Types type = (Types)Convert.ToInt32(Console.ReadLine());
            //    Tools tools= new Tools(type);
            //}
            //while (ifMakerEnd);
        }
        static void Main(string[] args)
        {
            Tools[] tools = new Tools[256];

            //Console.WriteLine("下面您将创建元件");
            //Stop:
            //Console.WriteLine("目前可供创建的类型:And,Or,Nand,Nor,Not");
            //Console.WriteLine("请输入您想创建的类型\"0,1,2,3,4\"");
            //Types type = (Types)Convert.ToInt32(Console.ReadLine());
            //tools[Tools.toolsNumber] = new Tools(type);
            //Console.WriteLine("是否要停止创建,输入\"stop\"停止");
            //if (Console.ReadLine() != "stop")
            //{
            //    goto Stop;
            //}
            Restart:
            switch (InputControl())
            {
                case 10000:
                    tools[Tools.toolsNumber] = new Tools(Types.And);
                    break;
                case 10001:
                    tools[Tools.toolsNumber] = new Tools(Types.Or);
                    break;
                case 10002:
                    tools[Tools.toolsNumber] = new Tools(Types.Nand);
                    break;
                case 10003:
                    tools[Tools.toolsNumber] = new Tools(Types.Nor);
                    break;
                case 10004:
                    tools[Tools.toolsNumber] = new Tools(Types.Not);
                    break;
                case 10010:
                    Console.WriteLine("请输入所要查询元件的编号");
                    tools[Convert.ToInt32(Console.ReadLine())].Check();
                    break;
            }
            goto Restart;

            

            
        }
    }
}
