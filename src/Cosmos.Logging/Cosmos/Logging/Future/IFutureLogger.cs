using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.LogFields;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Future {
    /// <summary>
    /// Future logger
    /// </summary>
    public interface IFutureLogger {
        /// <summary>
        /// Use fields
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        IFutureLogger UseFields(params ILogField[] fields);

        /// <summary>
        /// Set log event level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        IFutureLogger SetLevel(LogEventLevel level);

        /// <summary>
        /// Set excepton
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        IFutureLogger SetException(Exception exception);

        /// <summary>
        /// Set message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IFutureLogger SetMessage(string message);

        /// <summary>
        /// Append message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IFutureLogger AppendMessage(string message);

        /// <summary>
        /// Set parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        IFutureLogger SetParameter(object parameter);

        /// <summary>
        /// Set parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IFutureLogger SetParameters(params object[] parameters);

        /// <summary>
        /// Set tags
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        IFutureLogger SetTags(params string[] tags);

        /// <summary>
        /// Set track info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IFutureLogger SetTrackInfo(string id);

        /// <summary>
        /// Set track info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IFutureLogger SetTrackInfo(string id, string name);

        /// <summary>
        /// Set track info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="businessTraceId"></param>
        /// <returns></returns>
        IFutureLogger SetTrackInfo(string id, string name, string businessTraceId);

        /// <summary>
        /// Set track info
        /// </summary>
        /// <param name="trackId"></param>
        /// <returns></returns>
        IFutureLogger SetTrackInfo(TrackField.TrackValue trackId);

        /// <summary>
        /// Append additional operation
        /// </summary>
        /// <param name="additionalOperation"></param>
        /// <returns></returns>
        IFutureLogger AppendAdditionalOperation(IAdditionalOperation additionalOperation);

        /// <summary>
        /// Submit
        /// </summary>
        void Submit();
    }
}