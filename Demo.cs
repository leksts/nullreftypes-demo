namespace NullRefTypesDemo;

public class Consumer
{
    public void DoWork()
    {
        Dto? dto = GetDto();

        if (dto is null)
        {
            throw new InvalidOperationException("We made a booboo");
        }

        Service service = new(dto);
    }

    private Dto? GetDto()
    {
        if (new Random().Next(0, 1) == 1)
        {
            return new Dto { Value1 = 1, Value2 = 2 };
        }
        else
        {
            return null;
        }
    }
}

internal class Service
{
    int value1;
    int value2;

    public Service(Dto dto)
    {
        value1 = dto.Value1;
        value2 = dto.Value2;
    }
}

public class Dto
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
}
