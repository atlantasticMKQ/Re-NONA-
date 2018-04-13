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
        public static int[] usedPorts = new int[byte.MaxValue];
        public static int usedPortsIndex = 0;
    }
    class Tools
    {
        public static int toolsNumber = 0;
        public Types type;
        public int inputNumber;
        public int outputNumber;
        public int[] inputPort ;
        public int[] outputPort;
        public int toolnumber;
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
                Console.WriteLine("输入[{0}]端口: ", i );
                inputPort[i] = Convert.ToInt32(Console.ReadLine());
                Ports.usedPorts[Ports.usedPortsIndex] = inputPort[i];
                Ports.usedPortsIndex++;
            }
            for (int i = 0; i < outputNumber; i++)
            {
                Console.WriteLine("输出[{0}]端口: ", i );
                outputPort[i] = Convert.ToInt32(Console.ReadLine());
                Ports.usedPorts[Ports.usedPortsIndex] = outputPort[i];
                Ports.usedPortsIndex++;
            }
            Console.Write("编号:[{0}],类型:{1} ", toolnumber, type);
            toolnumber = toolsNumber;
            toolsNumber++;
        }
        public void Check()
        {
            Console.WriteLine("编号:[{0}],类型:[{1}] ",toolnumber,type);
            for (int i = 0; i < inputNumber; i++)
            {
                Console.Write("输入[{0}]端口{1} ", i ,inputPort[i]);
                Console.Write("状态[{0}] ",Ports.portsData[inputPort[i]]);
            }
            for (int i = 0; i < outputNumber; i++)
            {
                Console.Write("输出[{0}]端口{1} ", i, outputPort[i]);
                Console.Write("状态[{0}] ", Ports.portsData[outputPort[i]]);
            }
        }
    }
    
    class Program
    {
        static Tools[] tools = new Tools[byte.MaxValue];
        static void Check()
        {
            Console.WriteLine("元件编号 ");
            int checkValue = Convert.ToInt32(Console.ReadLine());
            if (checkValue < Tools.toolsNumber)
            {
                tools[checkValue].Check();
            }
            else
            {
                Console.WriteLine("未创建 ");
            }
        }
        static void InputControl()
        {
            Console.WriteLine();
            Console.WriteLine("指令:new,check,run,ports ");
            switch (Console.ReadLine())
            {
                case "new":
                    Console.WriteLine("类型:And,Or,Nand,Nor,Not ");
                    switch (Console.ReadLine())
                    {
                        case "And":
                            tools[Tools.toolsNumber] = new Tools(Types.And);
                            break;
                        case "Or":
                            tools[Tools.toolsNumber] = new Tools(Types.Or);
                            break;
                        case "Nand":
                            tools[Tools.toolsNumber] = new Tools(Types.Nand);
                            break;
                        case "Nor":
                            tools[Tools.toolsNumber] = new Tools(Types.Nor);
                            break;
                        case "Not":
                            tools[Tools.toolsNumber] = new Tools(Types.Not);
                            break;
                        default:
                            Console.Write(":未定义 ");
                            break;
                    }
                    break;
                case "check":
                    Check();
                    break;
                case "run":
                    Run();
                    break;
                case "ports":
                    //Array.Sort(Ports.usedPorts);
                    for (int i = 0; i < Ports.usedPortsIndex; i++)
                    {
                        Console.Write("{0}:[{1}] ", Ports.usedPorts[i], Ports.portsData[Ports.usedPorts[i]]);
                    }
                    //foreach(int index in Ports.usedPorts)
                    //{Console.Write("{0}:{1} ",index,Ports.portsData[index]);
                    //    
                    //}
                    break;
                default:
                    Console.Write(":未定义 ");
                    break;

            }
        }
        static void Run()
        {
            bool ifInputOver = false;
            string inputGet = null;
            while (!ifInputOver)
            {
                Console.WriteLine("通电端口,完毕:stop ");
                inputGet = Console.ReadLine();
                if (inputGet != "stop")
                    Ports.portsData[Convert.ToInt32(inputGet)] = true;
                else
                    ifInputOver = true;
            }
            ifInputOver = false;
            while (!ifInputOver)
            {
                Console.WriteLine("断电端口,完毕:stop ");
                inputGet = Console.ReadLine();
                if (inputGet != "stop")
                    Ports.portsData[Convert.ToInt32(inputGet)] = false;
                else
                    ifInputOver = true;
            }
            for (int i = 0; i < 100000; i++)
            foreach(Tools to in tools)
            {
                if (to == null)
                        break;
                switch (to.type)
                {
                    case Types.And:
                        Ports.portsData[to.outputPort[0]] = Ports.portsData[to.inputPort[0]] && Ports.portsData[to.inputPort[1]];
                        break;
                    case Types.Or:
                        Ports.portsData[to.outputPort[0]] = Ports.portsData[to.inputPort[0]] || Ports.portsData[to.inputPort[1]];
                        break;
                    case Types.Nand:
                        Ports.portsData[to.outputPort[0]] = !(Ports.portsData[to.inputPort[0]] && Ports.portsData[to.inputPort[1]]);
                        break;
                    case Types.Nor:
                        Ports.portsData[to.outputPort[0]] = !(Ports.portsData[to.inputPort[0]] || Ports.portsData[to.inputPort[1]]);
                        break;
                    case Types.Not:
                        Ports.portsData[to.outputPort[0]] = !Ports.portsData[to.inputPort[0]];
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Restart:
            //switch (InputControl())
            //{
            //    case 10000:
            //        tools[Tools.toolsNumber] = new Tools(Types.And);
            //        break;
            //    case 10001:
            //        tools[Tools.toolsNumber] = new Tools(Types.Or);
            //        break;
            //    case 10002:
            //        tools[Tools.toolsNumber] = new Tools(Types.Nand);
            //        break;
            //    case 10003:
            //        tools[Tools.toolsNumber] = new Tools(Types.Nor);
            //        break;
            //    case 10004:
            //        tools[Tools.toolsNumber] = new Tools(Types.Not);
            //        break;
            //    case 10010:
            //        Console.WriteLine("请输入所要查询元件的编号");
            //        int checkValue = Convert.ToInt32(Console.ReadLine());
            //        if (checkValue <= Tools.toolsNumber)
            //        {
            //            tools[checkValue].Check();
            //        }
            //        else
            //        {
            //            Console.WriteLine("您所要查询的元件尚未被创建");
            //        }
            //        break;
            //}
            InputControl();
            goto Restart;

            

            
        }
    }
}
