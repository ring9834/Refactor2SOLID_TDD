namespace MyLibrary;

public class After1
{
    public enum OperationType { Add, Subtract, Multiply }

    public double Calculate(int firstNumber, int secondNumber, OperationType operation)
    {
        return operation switch
        {
            OperationType.Add => firstNumber + secondNumber,
            OperationType.Subtract => firstNumber - secondNumber,
            OperationType.Multiply => firstNumber * secondNumber,
            _ => throw new ArgumentException("Invalid operation type", nameof(operation))
        };
    }
}
