using System;

namespace ArrayListLib
{
    public class ArrayList
    {
        private int[] _array;

        private int _currentIndex;

        public ArrayList(int size = 6) 
        {
            _array = new int[size];
            _currentIndex = 0;
        }

        public ArrayList(int[] array)
        {
            _array = new int[array.Length * 2];
            for(int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
            _currentIndex = array.Length;
        }

        public void Append(int number)
        {
            if(_currentIndex < _array.Length)
            {
                _array[_currentIndex] = number;
                _currentIndex++;
            } 
            else
            {
                DoubleTheArray();
                _array[_currentIndex] = number;
                _currentIndex++;
            }
        }

        public void Prepend(int number)
        {
            if (_currentIndex < _array.Length)
            {
                InsertValueInZeroIndex(number);
            }
            else
            {
                DoubleTheArray();
                InsertValueInZeroIndex(number);
            }
        }

        public void AddValueByIndex(int number, int index)
        {
            if(index < 0)
            {
                throw new IndexOutOfRangeException("Index should be 0 or higher");
            }
            if(index > _currentIndex)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if(_currentIndex == 0)
            {
                _array[0] = number;
                _currentIndex++;
            }
            else if (_currentIndex < _array.Length)
            {
                InsertElementByIndex(number, index); 
            }
            else
            {
                DoubleTheArray();
                InsertElementByIndex(number, index);
            }    
        }

        public void EraseLastElement()
        {
            if(_currentIndex > 0)
            {
                _currentIndex--;
            }
            if(_currentIndex == (int)_array.Length/4)
            {
                DeleteHalfArray();
            }
        }

        public void EraseFirstElement()
        {
            if (_currentIndex > 0)
            {
                for(int i = 0; i < _currentIndex; i++)
                {
                    _array[i] = _array[i + 1]; 
                }
                _currentIndex--;
                if (_currentIndex == (int)_array.Length / 4)
                {
                    DeleteHalfArray();
                }
            }
            
        }

        public void EraseByIndex(int index)
        {
            if(index < 0)
            {
                throw new ArgumentOutOfRangeException("index must be zero or greater than zero");
            }
            if(index >= _currentIndex)
            {
                throw new IndexOutOfRangeException("Index larger than array length");
            }
            if(_currentIndex > 0)
            {
                for (int i = index; i < _currentIndex; i++)
                {
                    _array[i] = _array[i + 1];
                }
                _currentIndex--;
                if (_currentIndex == (int)_array.Length / 4)
                {
                    DeleteHalfArray();
                }
            }    
        }

        public void EraseElementsFromEnd(int elementsAmount)
        {
            if(elementsAmount > _currentIndex)
            {
                throw new ArgumentOutOfRangeException("Amount of elements you want to erase is larger than elements amount in the array");
            }
            _currentIndex -= elementsAmount;
            if (_currentIndex <= (int)_array.Length / 4)
            {
                DeleteHalfArray();
            }
        }

        public void EraseElementsFromBeginning(int elementsAmount)
        {
            if(_currentIndex < elementsAmount)
            {
                throw new IndexOutOfRangeException("Amount of elements you want to erase is larger than elements amount in the array");
            }
            if(elementsAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("Elements amount can't be zero or negative");
            }

            for(int i = 0; i < _currentIndex - elementsAmount; i++)
            {
                _array[i] = _array[i + elementsAmount];
            }

            _currentIndex -= elementsAmount;

            if (_currentIndex <= (int)_array.Length / 4)
            {
                DeleteHalfArray();
            }
        }

        public void EraseElementsFromIndex(int elementsAmount, int index)
        {
            if (_currentIndex < elementsAmount)
            {
                throw new IndexOutOfRangeException("Amount of elements you want to erase is larger than elements amount in the array");
            }
            if (elementsAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("Elements amount can't be zero or negative");
            }
            if(index+elementsAmount >= _currentIndex)
            {
                throw new ArgumentOutOfRangeException("Amount of elements you want to erase is larger than elements amount in the array");
            }

            for (int i = index; i < _currentIndex; i++)
            {
                _array[i] = _array[i + elementsAmount];
            }

            _currentIndex -= elementsAmount;

            if (_currentIndex <= (int)_array.Length / 4)
            {
                DeleteHalfArray();
            }
        }

        public int GetLength()
        {
            return _currentIndex;
        }

        public int GetElementByIndex(int index)
        {
            if(index < 0 || index >= _currentIndex)
            {
                throw new ArgumentOutOfRangeException("Index cannot be less than zero or larger than the size of your array");
            }
            return _array[index];
        }

        public int GetFirstIndexByValue(int value)
        {
            for(int i = 0; i < _currentIndex; i++)
            {
                if(_array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void ChangeByIndex(int index, int number)
        {
            if (index < 0 || index >= _currentIndex)
            {
                throw new ArgumentOutOfRangeException("Index cannot be less than zero or larger than the size of your array");
            }

            _array[index] = number;
        }

        public void ReverseArray()
        {
            for(int i = 0; i<_currentIndex/2; i++)
            {
                int temp = _array[i];
                _array[i] = _array[_currentIndex - 1 - i];
                _array[_currentIndex - 1 - i] = temp;
            }
        }

        public int FindMaxValue()
        {
            if(_array.Length == 0)
            {
                throw new Exception("Array is empty");
            }
            int max = _array[0];
            for(int i = 1; i < _currentIndex; i++)
            {
                if(_array[i] > max)
                {
                    max = _array[i];
                }
            }

            return max;
        }

        public int FindMinValue()
        {
            if (_array.Length == 0)
            {
                throw new Exception("Array is empty");
            }
            int min = _array[0];
            for (int i = 1; i < _currentIndex; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }

            return min;
        }

        public int FindIndexOfMaxValue()
        {
            if (_array.Length == 0)
            {
                throw new Exception("Array is empty");
            }

            int max = _array[0];
            int maxIndex = 0;

            for (int i = 1; i < _currentIndex; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public int FindIndexOfMinValue()
        {
            if (_array.Length == 0)
            {
                throw new Exception("Array is empty");
            }

            int min = _array[0];
            int minIndex = 0;

            for (int i = 1; i < _currentIndex; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public void SortAscending()
        {
            int temp;
            for (int j = 0; j <= _array.Length - 2; j++)
            {
                for (int i = 0; i <= _array.Length - 2; i++)
                {
                    if (_array[i] > _array[i + 1])
                    {
                        temp = _array[i + 1];
                        _array[i + 1] = _array[i];
                        _array[i] = temp;
                    }
                }
            }
        }

        public void SortDescending()
        {
            int temp;
            for (int j = 0; j <= _array.Length - 2; j++)
            {
                for (int i = 0; i <= _array.Length - 2; i++)
                {
                    if (_array[i] < _array[i + 1])
                    {
                        temp = _array[i + 1];
                        _array[i + 1] = _array[i];
                        _array[i] = temp;
                    }
                }
            }
        }

        public int EraseFirstElementByValue(int value)
        {
            int index = GetFirstIndexByValue(value);
            if(index == -1)
            {
                return index;
            }
            EraseByIndex(index);
            return index;
        }

        public int EraseAllElementsByValue(int value)
        {
            int index = -1;
            int count = -1;
            do
            {
                index = GetFirstIndexByValue(value);
                count++;
            }
            while (index != -1);

            return count;
        }

        public void AppendArray(int[] array)
        {
            AddArrayByIndex(array, _currentIndex);
        }

        public void AddArrayByIndex(int[] array, int index)
        {
            if (_currentIndex + array.Length >= _array.Length)
            {
                DoubleTheArray();
            }

            int newLen = array.Length;

            for(int i = _currentIndex + newLen; i < index + newLen; i--)
            {
                _array[i] = _array[i - newLen];
            }
            for(int i = index, j = 0; j < newLen; i++, j++)
            {
                _array[i] = array[j];
            }

            _currentIndex = _currentIndex + newLen;
        }

        public void PrependArray(int[] array)
        {
            AddArrayByIndex(array, 0);
        }

        private void DoubleTheArray()
        {
            int[] newArr = new int[_currentIndex * 2];

            for (int i = 0; i < _array.Length; i++)
            {
                newArr[i] = _array[i];
            }

            _array = newArr;
        }

        private void DeleteHalfArray()
        {
            int[] newArr = new int[_currentIndex * 2];

            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = _array[i];
            }

            _array = newArr;
        }

        private void InsertValueInZeroIndex(int number)
        {
            for (int i = _currentIndex; i > 0; i--)
            {
                _array[i] = _array[i - 1];

            }
            _array[0] = number;
            _currentIndex++;
        }

        private void InsertElementByIndex(int number, int index)
        {
            for (int i = _currentIndex; i >= index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = number;
            _currentIndex++;
        }
    }
}
