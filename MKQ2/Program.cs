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
                reset:
                Console.WriteLine("输入[{0}]端口: ", i );
                try
                {
                    
                    inputPort[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("请重新输入");
                    goto reset;
                }
                Ports.usedPorts[Ports.usedPortsIndex] = inputPort[i];
                Ports.usedPortsIndex++;
            }
            for (int i = 0; i < outputNumber; i++)
            {
                reset1:
                Console.WriteLine("输出[{0}]端口: ", i );
                try
                {
                    
                    outputPort[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("请重新输入");
                    goto reset1;
                }
                
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
            int checkValue;
            reset2:
            try
            {
                
                checkValue = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("请重新输入");
                goto reset2;
            }
            
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
            Console.WriteLine("指令:new,check,run,ports,help ");
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
                    for (int i = 0; i < Ports.usedPortsIndex; i++)
                    {
                        Console.Write("{0}:[{1}] ", Ports.usedPorts[i], Ports.portsData[Ports.usedPorts[i]]);
                    }
                    break;
                case "help":
                    Console.WriteLine("本游戏由端口替代导线,允许玩家在端口之间创建逻辑门\n" +
                        "目前支持的逻辑门有:\n" +
                        "->And:仅当两个输入端同时有电时才输出电流\n" +
                        "->Or:只要有一个输入端有电便输出电流\n" +
                        "->Nand:仅当两个输入端口都有电时才不输出电流\n" +
                        "->Nor:仅当两个输入端口都没电时才输出电流\n" +
                        "->Not:输入端口与输出端口状态相反\n\n" +
                        "目前的版本不支持会造成矛盾的电路所带来的快速变化电流(端口除非改变,通电状态应该是一定的)\n" +
                        "如果输入错误会导致程序崩溃而非重新输入\n" +
                        "true:有电false:没电\n" +
                        "支持的指令如下:\n" +
                        "->new:创建新元件\n" +
                        "->check:检查元件状态\n" +
                        "->run:运行元件\n" +
                        "->ports:显示端口状态(待改进)\n" +
                        "[请注意大小写]");
                    break;
                case "MKQ":
                    Console.WriteLine("难道你想要个彩蛋?");
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
                {
                    reset3:
                    try
                    {
                        
                        Ports.portsData[Convert.ToInt32(inputGet)] = true;
                    }
                    catch
                    {
                        Console.WriteLine("请重新输入");
                        goto reset3;
                    }
                    
                }
                else
                    ifInputOver = true;
            }
            ifInputOver = false;
            while (!ifInputOver)
            {
                Console.WriteLine("断电端口,完毕:stop ");
                inputGet = Console.ReadLine();
                if (inputGet != "stop")
                {
                    reset4:
                    try
                    {
                        
                        Ports.portsData[Convert.ToInt32(inputGet)] = false;
                    }
                    catch
                    {
                        Console.WriteLine("请重新输入");
                        goto reset4;
                    }
                    
                }
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
            Console.WriteLine("#如果是第一次玩,请输入[help]再摁回车");
            Restart:
            InputControl();
            goto Restart;
        }
    }
}
