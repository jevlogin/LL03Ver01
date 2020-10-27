using System;


namespace JevLogin
{
    public abstract class DisposeExample : IDisposable
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //  Освобождаем управляемые ресурсы
                }
                //  Освобождаем неуправляемые объекты
                _disposed = true;
            }
        }

        //  Деструктор
        ~DisposeExample()
        {
            Dispose(false);
        }
    }

    public sealed class Derived : DisposeExample
    {
        private bool _isDisposed = false;

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                if (disposing)
                {
                    //  освобождение управляемых ресурсов
                }
                _isDisposed = true;
            }
            //  Обращаемся к методу Dispose базового класса
            base.Dispose(disposing);
        }
    }
}
