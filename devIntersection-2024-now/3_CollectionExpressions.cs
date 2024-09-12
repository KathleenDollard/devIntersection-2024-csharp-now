internal class CollectionExpressions
{
    public void OldInitialization()
    {
        int[] x1 = new int[] { 1, 2, 3, 4 };
        int[] x2 = Array.Empty<int>();
        WriteByteArray(new byte[] { (byte)1, (byte)2, (byte)3 });
        List<int> x4 = new() { 1, 2, 3, 4 };
        Span<DateTime> dates = stackalloc DateTime[] { GetDate(0), GetDate(1) };
    }

    //public void NewInitialization()
    //{
    //    int[] x1 = [1, 2, 3, 4];
    //    int[] x2 = [];
    //    WriteByteArray([1, 2, 3]);
    //    List<int> x4 = [1, 2, 3, 4];
    //    Span<DateTime> dates = [GetDate(0), GetDate(1)];
    //}

    //public void ButWaitTheresMore()
    //{
    //    int[] x2 = []; // Empty array

    //    // Common interfaces have default implementations
    //    IEnumerable<int> ints = [1, 2, 3];
    //    // The collection is created with the correct length

    //    // Slice/range syntax supported
    //    IEnumerable<int> ints2 = [.. ints.Select(x => x ^ 2), 16, 25];
    //}

    private void WriteByteSpan(Span<byte> span)
    {
        throw new NotImplementedException();
    }

    private void WriteByteArray(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    private DateTime GetDate(int v)
    {
        throw new NotImplementedException();
    }
}
