using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrismDemo2.Services;

public class CameraControl
{
    public CameraControl()
    {
        // 초기화 테스트 코드
        Thread.Sleep(2000);

        // Value 값이 1로 유지되면 Singleton
        Value++;
    }

    public int Value { get; set; }
}