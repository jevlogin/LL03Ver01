namespace JevLogin
{
    public class Swap
    {
        public void SwapTypeRef<T>(ref T A, ref T B)
        {
            T t;
            t = A;
            A = B;
            B = t;
        }
    }
}