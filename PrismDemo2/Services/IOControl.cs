using System.Threading;

namespace PrismDemo2.Services;

public class IOControl
{
    public IOControl()
    {
        // 초기화 테스트 코드
        Thread.Sleep(2000);
        Value++;
    }
    public static int Value { get; set; }
}