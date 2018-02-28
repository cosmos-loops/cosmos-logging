using System;
using System.IO;

namespace Cosmos.Logging.Sinks.File.Core {
    public class SizeLimitedStream : Stream {
        readonly Stream _stream;
        long _countedLength;

        public SizeLimitedStream(Stream stream) {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            _countedLength = stream.Length;
        }

        public long CountedLength => _countedLength;
        public override void Flush() => _stream.Flush();
        public override bool CanRead => false;
        public override bool CanSeek => _stream.CanSeek;
        public override bool CanWrite => true;
        public override long Length => _stream.Length;

        public override long Position {
            get => _stream.Position;
            set => throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin) =>
            throw new InvalidOperationException($"Seek operations are not available through `{nameof(SizeLimitedStream)}`.");

        public override void SetLength(long value) => throw new NotSupportedException();
        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) {
            _stream.Write(buffer, offset, count);
            _countedLength += count;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) _stream.Dispose();
            base.Dispose(disposing);
        }
    }
}