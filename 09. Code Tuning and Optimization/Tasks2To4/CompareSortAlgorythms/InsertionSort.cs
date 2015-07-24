namespace CompareSortAlgorythms
{
    public static class InsertionSort
    {  
        public static void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
                int index = i;
                while (index > 0 && arr[index - 1] >= value)
                {
                    arr[index] = arr[index - 1];
                    index--;
                }

                arr[index] = value;
            }
        }
    }
}