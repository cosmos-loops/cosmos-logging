using System;
using System.IO;

namespace Cosmos.Logging.Sinks.File.Core {
    /// <summary>
    /// Size limited stream
    /// </summary>
    public class SizeLimitedStream : Stream {
        readonly Stream _stream;
        long _countedLength;

        /// <inheritdoc />
        public SizeLimitedStream(Stream stream) {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            _countedLength = stream.Length;
        }

        /// <summary>
        /// Gets counted lenfth
        /// </summary>
        public long CountedLength => _countedLength;

        /// <inheritdoc />
        public override void Flush() => _stream.Flush();

        /// <inheritdoc />
        public override bool CanRead => false;

        /// <inheritdoc />
        public override bool CanSeek => _stream.CanSeek;

        /// <inheritdoc />
        public override bool CanWrite => true;

        /// <inheritdoc />
        public override long Length => _stream.Length;

        /// <inheritdoc />
        public override long Position {
            get => _stream.Position;
            set => throw new NotSupportedException();
        }

        /// <inheritdoc />
        public override long Seek(long offset, SeekOrigin origin) =>
            throw new InvalidOperationException($"Seek operations are not available through `{nameof(SizeLimitedStream)}`.");

        /// <inheritdoc />
        public override void SetLength(long value) => throw new NotSupportedException();

        /// <inheritdoc />
        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        /// <inheritdoc />
        public override void Write(byte[] buffer, int offset, int count) {
            _stream.Write(buffer, offset, count);
            _countedLength += count;
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing) {
            if (disposing) _stream.Dispose();
            base.Dispose(disposing);
        }
    }
}