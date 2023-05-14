using Generated;
using System;
using System.Collections.Generic;

namespace CalculatorServer.Actions
{
  internal sealed class Calculator
  {
    #region Constants
    private const int MinimumOperands = 2;
    private readonly Stack<double> numbers = new Stack<double>();
    #endregion

    #region Properties
    public bool CanCalculate
    {
      get
      {
        return this.numbers.Count >= MinimumOperands;
      }
    }
    #endregion

    #region Public methods
    public void AddOperand(double operand)
    {
      this.numbers.Push(operand);
    }
    public double Calculate(OperationType operationType)
    {
      return CanCalculate ? Compute(operationType)(GetOperand(), GetOperand()) : (default);
    }
    #endregion

    #region Private methods
    private Func<double, double, double> Compute(OperationType operationType)
    {
      switch (operationType)
      {
        case OperationType.Addition:
          return Operations.Add;
        case OperationType.Subtraction:
          return Operations.Substract;
        case OperationType.Multiplication:
          return Operations.Multiply;
        case OperationType.Division:
          return Operations.Divide;
        case OperationType.InvalidOperation:
        default:
          return Operations.Add;
      }
    }
    private double GetOperand()
    {
      try
      {
        return this.numbers.Pop();
      }
      catch
      {
        return default;
      }
    }
    #endregion
  }
}
