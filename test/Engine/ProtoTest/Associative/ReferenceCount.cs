using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using ProtoCore.DSASM.Mirror;
using ProtoCore.Lang;
using ProtoTest.TD;
using ProtoTestFx.TD;
namespace ProtoTest.Associative
{
    class ReferenceCount
    {
        public TestFrameWork thisTest = new TestFrameWork();

        [Test]
        public void TestReferenceCount_BaseCase01()
        {
            string code = @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a", 0);
        }

        [Test]
        public void TestReferenceCount01_NoFunctionCall()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount01_NoFunctionCall_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount02_FunctionNonArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount02_FunctionNonArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount03_FunctionReplication()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount03_FunctionReplication_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount04_FunctionArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount04_FunctionArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount05_StaticFunctionNonArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount05_StaticFunctionNonArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount06_StaticFunctionReplication()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount06_StaticFunctionReplication_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount07_StaticFunctionArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount07_StaticFunctionArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount08_MemFunctionNonArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount08_MemFunctionNonArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount09_MemFunctionReplication()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount09_MemFunctionReplication_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount10_MemFunctionArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount10_MemFunctionArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount11_ReplicationNonArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount11_ReplicationNonArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount12_ReplicationReplication()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount12_ReplicationReplication_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount13_ReplicationArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("a", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount13_ReplicationArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount14_GlobalFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
        }

        [Test]
        public void TestReferenceCount14_GlobalFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount15_GlobalFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount15_GlobalFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount16_GlobalFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
        }

        [Test]
        public void TestReferenceCount16_GlobalFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount17_StaticFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
        }

        [Test]
        public void TestReferenceCount17_StaticFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount18_StaticFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("b", 0);
        }

        [Test]
        public void TestReferenceCount18_StaticFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount19_StaticFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
        }

        [Test]
        public void TestReferenceCount19_StaticFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
        }

        [Test]
        public void TestReferenceCount20_MemberFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("a", 0);
        }

        [Test]
        public void TestReferenceCount20_MemberFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount21_MemberFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("a", 0);
        }

        [Test]
        public void TestReferenceCount21_MemberFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount22_MemberFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("a", 0);
        }

        [Test]
        public void TestReferenceCount22_MemberFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount23_MemberFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
        }

        [Test]
        public void TestReferenceCount23_MemberFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount24_MemberFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
        }

        [Test]
        public void TestReferenceCount24_MemberFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount25_MemberFunctionTwoArguments()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
        }

        [Test]
        public void TestReferenceCount25_MemberFunctionTwoArguments_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount26_GlobalFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount26_GlobalFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount27_GlobalFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount27_GlobalFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount28_GlobalFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount28_GlobalFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount29_MemberFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount29_MemberFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount30_MemberFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount30_MemberFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount31_MemberFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount31_MemberFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount32_StaticFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount32_StaticFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount33_StaticFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount33_StaticFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount34_StaticFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount34_StaticFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount35_StaticFunctionReturnObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount35_StaticFunctionReturnObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount36_StaticFunctionReturnObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount36_StaticFunctionReturnObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount37_MemberFunctionReturnObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount37_MemberFunctionReturnObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount38_MemberFunctionReturnObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount38_MemberFunctionReturnObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount39_GlobalFunctionReturnObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount39_GlobalFunctionReturnObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount40_GlobalFunctionReturnObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount40_GlobalFunctionReturnObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount41_MemberFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount41_MemberFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount42_MemberFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount42_MemberFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount43_MemberFunctionReturnArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount43_MemberFunctionReturnArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount44_MemberFunctionReturnObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount44_MemberFunctionReturnObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount45_MemberFunctionReturnObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount45_MemberFunctionReturnObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount46_GlobalFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount46_GlobalFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount47_GlobalFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount47_GlobalFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount48_GlobalFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount48_GlobalFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount49_MemberFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount49_MemberFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount50_MemberFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount50_MemberFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount51_MemberFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount51_MemberFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount52_StaticFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount52_StaticFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount53_StaticFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount53_StaticFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount54_StaticFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount54_StaticFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount55_StaticFunctionReturnNewObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount55_StaticFunctionReturnNewObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount56_StaticFunctionReturnNewObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount56_StaticFunctionReturnNewObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount57_MemberFunctionReturnNewObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount57_MemberFunctionReturnNewObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount58_MemberFunctionReturnNewObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount58_MemberFunctionReturnNewObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount59_GlobalFunctionReturnNewObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount59_GlobalFunctionReturnNewObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount60_GlobalFunctionReturnNewObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount60_GlobalFunctionReturnNewObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount61_MemberFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount61_MemberFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount62_MemberFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount62_MemberFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount63_MemberFunctionReturnNewArray()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount63_MemberFunctionReturnNewArray_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount64_MemberFunctionReturnNewObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount64_MemberFunctionReturnNewObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount65_MemberFunctionReturnNewObject()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.VerifyReferenceCount("a1", 0);
            thisTest.VerifyReferenceCount("a2", 0);
            thisTest.VerifyReferenceCount("a3", 0);
            thisTest.VerifyReferenceCount("b1", 0);
            thisTest.VerifyReferenceCount("b2", 0);
            thisTest.VerifyReferenceCount("b3", 0);
            thisTest.VerifyReferenceCount("c1", 0);
            thisTest.VerifyReferenceCount("c2", 0);
            thisTest.VerifyReferenceCount("c3", 0);
            thisTest.VerifyReferenceCount("as", 0);
            thisTest.VerifyReferenceCount("bs", 0);
            thisTest.VerifyReferenceCount("cs", 0);
            thisTest.VerifyReferenceCount("x", 0);
        }

        [Test]
        public void TestReferenceCount65_MemberFunctionReturnNewObject_Dispose()
        {
            string code =
                @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            thisTest.Verify("aDispose", 0);
            thisTest.Verify("bDispose", 0);
            thisTest.Verify("cDispose", 0);
        }

        [Test]
        public void TestReferenceCount66_DID1467277()
        {
            string code = @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            // SSA'd transforms will not GC the temps until end of block
            // However, they must be GC's after every line when in debug step over
            thisTest.Verify("t", 0);
        }

        [Test]
        public void TestReferenceCount67_DID1467277_02()
        {
            string code = @"
            ExecutionMirror mirror = thisTest.RunScriptSource(code);
            // SSA'd transforms will not GC the temps until end of block
            // However, they must be GC's after every line when in debug setp over
            thisTest.Verify("t", 0);
        }

        [Test]
        public void TestReferenceCount68_TemporaryArrayIndexing01()
        {
            string code = @"
            string errorString = "";
            thisTest.RunScriptSource(code, errorString);
            thisTest.Verify("d", 3);
        }

        [Test]
        public void TestReferenceCount69_TemporaryArrayIndexing02()
        {
            string code = @"
            string errorString = "";
            thisTest.RunScriptSource(code, errorString);
            thisTest.Verify("d", 2);
        }

        [Test]
        public void TestReferenceCount70_TemporaryArrayIndexing03()
        {
            string code = @"
            string errorString = "";
            thisTest.RunScriptSource(code, errorString);
            thisTest.Verify("d", 2);
        }

        [Test]
        public void TestReferenceCount71_TemporaryArrayIndexing04()
        {
            string code = @"
            string errorString = "";
            thisTest.RunScriptSource(code, errorString);
            thisTest.Verify("d", 4);
        }

        [Test]
        public void TestReferenceCount72_TemporaryDefaultArgument()
        {
            string code = @"
            string errorString = "";
            thisTest.RunScriptSource(code, errorString);
            thisTest.Verify("d", 1);
        }

        [Test]
        public void TestReferenceCount73_FunctionPointer()
        {
            string code = @"
            string errorString = "";
            thisTest.RunScriptSource(code, errorString);
            thisTest.Verify("d", 1);
        }

        [Test]
        public void T074_DG1465049()
        {
            string code = @"
            thisTest.RunScriptSource(code);

            // IT gc's the line where it calls translate when variable as is nullified
            // It disposes 3 ssa temporaries and 1 element in the array 'as'
            thisTest.Verify("d", 4);
        }

        [Test]
        public void TestReferenceCountForMembers()
        {
            string code = @"
            thisTest.RunScriptSource(code, "");
            thisTest.Verify("a_dispose", 1);
        }

        [Test]
        public void TestReferenceCountForStaticMembers()
        {
            string code = @"
            thisTest.RunScriptSource(code, "");
            thisTest.Verify("a_dispose", 1);
        }

        [Test]
        public void TestReferenceCountForStaticMembers2()
        {
            string code = @"
            thisTest.RunScriptSource(code, "");
            thisTest.Verify("a_dispose", 2);
        }
    }
}