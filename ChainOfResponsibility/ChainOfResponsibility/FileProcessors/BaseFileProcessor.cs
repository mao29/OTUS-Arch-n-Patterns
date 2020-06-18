using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Базовый класс для обработчиков файлов.
    /// </summary>
    public abstract class BaseFileProcessor : IFileProcessor
    {
        /// <summary>
        /// Пустой обработчик файлов, который добавляется в конец цепочки обработчиков.
        /// </summary>
        class NullFileProcessor : BaseFileProcessor
        {
            /// <summary>
            /// Создать пустой обработчик файлов.
            /// </summary>
            /// <param name="logger"></param>
            public NullFileProcessor(ILogger logger) : base(logger)
            { }

            /// <inheritdoc/>
            protected override bool CanHandle(string filePath)
            {
                return true;
            }

            /// <inheritdoc/>
            protected override void DoProcessFile(string filePath)
            {
                ReportProcessing($"Обработчика для файла {filePath} не найдено.");
            }
        }

        /// <summary>
        /// Следующий обработчик цепочки обработчиков.
        /// </summary>
        protected IFileProcessor _next;
        
        /// <summary>
        /// Логгер сообщений.
        /// </summary>
        private ILogger _logger;

        protected IFileProcessor Next
        {
            get 
            {
                if (_next == null)
                {
                    _next = new NullFileProcessor(_logger);
                }
                return _next;
            }
        }

        /// <summary>
        /// Создать базовый обработчик файлов.
        /// </summary>
        /// <param name="logger">Логгер сообщений.</param>
        public BaseFileProcessor(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public void ProcessFile(string filePath)
        {
            if (CanHandle(filePath))
            {
                DoProcessFile(filePath);
            }
            else
            {
                Next.ProcessFile(filePath);
            }
        }

        /// <inheritdoc/>
        public void SetNext(IFileProcessor fileProcessor)
        {
            _next = fileProcessor;
        }

        /// <summary>
        /// Залогировать сообщение об обработке файла.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        protected void ReportProcessing(string message)
        {
            _logger.WriteMessage(message);
        }

        /// <summary>
        /// Проверить, может ли обработчик обработать заданный файл.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        /// <returns>true, если обработчик может обработать заданный файл, иначе - false.</returns>
        protected abstract bool CanHandle(string filePath);

        /// <summary>
        /// Обработать файл.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        protected abstract void DoProcessFile(string filePath);
    }
}
