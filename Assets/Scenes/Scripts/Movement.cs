public class Velocity2D
{
    public float velX;
    public float velY;
}

public class Velocity
{
    public float velX;
    public float velY;
    public float velZ;
}

public class Position2D
{
    public float x;
    public float y;
}

public class Position
{
    public float x;
    public float y;
    public float z;
}

public static class PhyConstants
{
    public const float gravity = 9.8f;
}
public enum TypeOfFluid { Water, Propane, Mercury }
public enum TypeOfMaterial { Wood, Stone, Plastic }

public static class FluidDensity
{
    public const float water = 0.1f;
    public const float propane = 0.493f;
    public const float mercury = 0.359f;
}

public static class MaterialDensity
{
    public const float wood = 0.06f;
    public const float stone = 0.15f;
    public const float plastic = 0.05f;
}