using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString
{
    /// <summary>
    /// Стек пользовательских строк.
    /// </summary>
    public class CustomStringStack
    {
        /// <summary>
        /// Элементы, помещенные в стек.
        /// </summary>
        private ICustomString[] _elements;

        /// <summary>
        /// Индекс верхнего элемента стека.
        /// </summary>
        private int _currentHeadIndex;

        /// <summary>
        /// Класс, отвечающий за изменение размера стека.
        /// </summary>
        public IArrayResizer<ICustomString> ArrayResizer { get; set; }

        /// <summary>
        /// Создать стек пользовательских строк с настройками по умолчанию.
        /// /// </summary>
        public CustomStringStack() : this(10)
        { }

        /// <summary>
        /// Создать стек пользовательских строк с заданной стратегией изменения размера стека.
        /// </summary>
        /// <param name="arrayResizer">Стратегия изменения размера стека.</param>
        public CustomStringStack(IArrayResizer<ICustomString> arrayResizer) : this(10, arrayResizer)
        { }

        /// <summary>
        /// Создать стек пользовательских строк заданной начальной емкости.
        /// </summary>
        /// <param name="capacity">Начальная емкость стека.</param>
        public CustomStringStack(int capacity) : this(capacity, null)
        {
        }

        /// <summary>
        /// Создать стек пользовательских строк заданной начальной емкости и с заданной стратегией изменения размера стека.
        /// </summary>
        /// <param name="capacity">Начальная емкость.</param>
        /// <param name="arrayResizer">Стратегия изменения размера стека.</param>
        public CustomStringStack(int capacity, IArrayResizer<ICustomString> arrayResizer)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity should be greater than 0.");
            }

            _elements = new ICustomString[capacity];
            ArrayResizer = arrayResizer ?? new LogarithmicArrayResizer<ICustomString>(capacity);
            _currentHeadIndex = -1;
        }

        /// <summary>
        /// Поместить элемент в стек.
        /// </summary>
        /// <param name="element">Пользовательская строка.</param>
        public void Push(ICustomString element)
        {
            _currentHeadIndex++;

            if (ArrayResizer.CanIncreaseArray(_elements.Length, _currentHeadIndex))
            {
                _elements = ArrayResizer.IncreaseArray(_elements, _currentHeadIndex);
            }

            if (_currentHeadIndex >= _elements.Length)
            {
                throw new StackOverflowException();
            }

            _elements[_currentHeadIndex] = element;
        }

        /// <summary>
        /// Извлечь пользовательскую строку из стека.
        /// </summary>
        /// <returns>Пользовательская строка с вершины стека.</returns>
        /// <exception cref="InvalidOperationException"/>
        public ICustomString Pop()
        {
            return Pop(true);
        }

        /// <summary>
        /// Извлечь пользовательскую строку из стека.
        /// </summary>
        /// <param name="resizeAllowed">Позволено ли осуществлять изменение размеров стека при совершении операции.</param>
        /// <returns>Пользовательская строка с вершины стека.</returns>
        ///  /// <exception cref="InvalidOperationException"/>
        private ICustomString Pop(bool resizeAllowed)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var result = _elements[_currentHeadIndex];
            _currentHeadIndex--;

            if (resizeAllowed && ArrayResizer.CanDecreaseArray(_elements.Length, _currentHeadIndex + 1))
            {
                _elements = ArrayResizer.DecreaseArray(_elements, _currentHeadIndex + 1);
            }

            return result;
        }

        /// <summary>
        /// Получить элемент, находящийся на вершине стека, без его извлечения из стека.
        /// </summary>
        /// <returns>Пользовательская строка с вершины стека.</returns>
        /// <exception cref="InvalidOperationException"/>
        public ICustomString Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var result = _elements[_currentHeadIndex];
            return result;
        }

        /// <summary>
        /// Проверить, является ли стек пустым.
        /// </summary>
        /// <returns>true, если стек пустой, false - иначе.</returns>
        public bool IsEmpty()
        {
            return _currentHeadIndex < 0;
        }

        /// <summary>
        /// Извлечь все элементы из стека.
        /// </summary>
        /// <returns>Массив элементов, извлеченных из стека.</returns>
        public ICustomString[] PopAll()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            ICustomString[] result = new ICustomString[_currentHeadIndex];
            int currentIndex = 0;
            while (!IsEmpty())
            {
                result[currentIndex] = Pop(false);
                currentIndex++;
            }

            if (ArrayResizer.CanDecreaseArray(_elements.Length, _currentHeadIndex + 1))
            {
                _elements = ArrayResizer.DecreaseArray(_elements, _currentHeadIndex + 1);
            }

            return result;
        }
    }
}
