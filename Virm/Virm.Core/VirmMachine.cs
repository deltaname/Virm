using System.Collections.Generic;
using Virm.Core.Environment;
using Virm.Core.Execution;
using Virm.Core.LangStructures;
using Virm.Core.LangStructures.Exceptions;

namespace Virm.Core
{
    public class VirmMachine
    {
        private VirmInterpreter interpreter;
        private Stack<VirmContainer> stack;

        public VirmMachine()
        {
            interpreter = new VirmInterpreter();
            stack = new Stack<VirmContainer>();
        }

        public void Execute(string code)
        {
            var exec = interpreter.InterpretCode(code)[0];

            while (exec.Next != null)
            {
                exec = exec.Next;
            }

            stack.Push((exec as VirmExecContainer).Container);

            while(exec.Prev != null)
            {
                VirmMethod command = (exec.Prev as VirmExecMethod).Method;

                switch (command.GetMethodType())
                {
                    case VirmMethodType.ArgAction:
                        if (stack.Count == 0)
                            throw new VirmExecutionException("Stack is empty");
                        command.ExecuteAction(stack.Pop());
                        break;
                    case VirmMethodType.ArgFunction:
                        if (stack.Count == 0)
                            throw new VirmExecutionException("Stack is empty");
                        stack.Push(command.ExecuteFunc(stack.Pop()));
                        break;
                    case VirmMethodType.NoArgAction:
                        command.ExecuteAction();
                        break;
                    case VirmMethodType.NoArgFunction:
                        stack.Push(command.ExecuteFunc());
                        break;
                }

                exec = exec.Prev;
            }

        }
    }
}
