using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RunawayRecursion;

/// <summary>
/// The following unit test demonstrates how runaway recursion in a test can result in the Test
/// Explorer displaying out-dated output. If this unit test is run, it will run for a while and
/// then conclude without displaying the debugging output "Starting test." and with the blue
/// "not-run" status indicator. If this unit test is run in debugging mode, then the final line
/// in the "Output" window will be: 
/// "The program '[11308] testhost.exe' has exited with code 3221225477 (0xc0000005) 'Access violation'."
/// The 'Starting test.' message is displayed there, though it can be easily missed by the user.
/// </summary>
[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Debug.WriteLine("Starting test.");
        //throw new NotImplementedException();
        TestFuncOne();
    }

    private static void TestFuncOne()
    {
        TestFuncTwo();
    }

    private static void TestFuncTwo()
    {
        TestFuncOne();
    }
}
