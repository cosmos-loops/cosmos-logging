using System;
using System.IO;
using System.Text;

namespace Cosmos.Logging.Sinks.File.Core {
    public sealed class FileAstronaut {
        private readonly object _syncRoot = new object();
        readonly TextWriter _output;
        readonly FileStream _underlyingStream;
        private readonly SizeLimitedStream _sizeLimitedStream;
        readonly long? _fileSizeLimitBytes;
        readonly bool _buffered;

        public FileAstronaut(string path, long? fileSizeLimitBytes, Encoding encoding = null, bool buffered = false) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (fileSizeLimitBytes.HasValue && fileSizeLimitBytes < 0) throw new ArgumentException("Negative value provided; file size limit must be non-negative.");

            _fileSizeLimitBytes = fileSizeLimitBytes;
            _buffered = buffered;

            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            Stream output = _underlyingStream = System.IO.File.Open(path, FileMode.Append, FileAccess.Write, FileShare.Read);
            if (fileSizeLimitBytes != null) {
                output = _sizeLimitedStream = new SizeLimitedStream(_underlyingStream);
            }

            _output = new StreamWriter(output, encoding ?? new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        }

        public void FlushToDisk() {
            lock (_syncRoot) {
                _output.Flush();
                _underlyingStream.Flush(true);
            }
        }
    }
}