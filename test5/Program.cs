using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("메인 메서드 시작");

        // 비동기 메서드 호출 및 기다림
        MyAsyncMethod();

        Console.WriteLine("메인 메서드 종료");
    }

    static async void MyAsyncMethod()
    {
        Console.WriteLine("비동기 메서드 시작");

        // 비동기적으로 어떤 작업 수행
        await Task.Delay(2000);

        Console.WriteLine("비동기 메서드 종료");
    }
}