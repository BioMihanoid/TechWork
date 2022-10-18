using System;
using System.Diagnostics;

class Program
{
	static void Main(string[] args)
	{
		try
		{
			FailProcess();
		}
		catch { }

		Console.WriteLine("Failed to fail process!");
		Console.ReadKey();
	}

	static void FailProcess()
	{
		Process.GetCurrentProcess().Kill(); // первый вариант
		//Environment.Exit(-1); второй вариант
		//Application.Exit() трейтий вариант в случае использования win forms


		//Варианты с перезагрузкой и выключением пк, а цикл чтобы программа дождалась заверешения всех процеесов,
		//чтобы потом система сама принудительно остановила программу и выключила/перзагрузила компьютер

		//Process.Start("shutdown", "/r /t 0");
		//while(true) { }

		//Process.Start("shutdown", "/s /t 0");
		//while(true) { }


		//Самый изощерённый вариант(но в нём есть сомнения) - удалить system32, если работаешь под виндовс или удалить /,
		//если работаешь под unix подобными системами, но он будет требовать прав аднимистратора/суперпользователя
		//Задержка стоит на всякий случай, чтобы функция успела повисеть пока система не умрет и принудительно не остановит все процессы

		//Directory.Delete(@"C:\Windows\system32", true);
		//while(true) { }

		//Directory.Delete(@"/", true);
		//while(true) { }
	}
}