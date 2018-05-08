namespace Po.Result
{
    using System;

    /// <summary>
    /// 函式執行結果類別
    /// </summary>
    public class PoResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PoResult"/> class.
        /// </summary>
        public PoResult()
        {
            this.Success = false;
        }

        /// <summary>
        /// 執行是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 執行訊息
        /// </summary>
        public string Message { get; set; }

        #region Static
        /// <summary>
        /// 回傳成功，沒有訊息
        /// </summary>
        /// <returns>執行結果為成功。沒有Messge。</returns>
        public static PoResult PoSuccess()
        {
            return new PoResult { Success = true };
        }

        /// <summary>
        /// 回傳失敗，訊息如引號內 「<see cref="errorMsg"/>」
        /// </summary>
        /// <param name="errorMsg">錯誤訊息</param>
        /// <returns>執行結果為失敗。</returns>
        public static PoResult Fail(string errorMsg)
        {
            return new PoResult { Success = false, Message = errorMsg };
        }

        /// <summary>
        /// 回傳失敗，訊息如引號內 「執行失敗: <see cref="errorMsg"/>」
        /// </summary>
        /// <param name="errorMsg">錯誤訊息，訊息的前端將會被加入「執行失敗: 」字樣</param>
        /// <returns>執行結果為失敗。</returns>
        public static PoResult MsgWithRunFail(string errorMsg)
        {
            return new PoResult { Message = $"執行失敗: {errorMsg}" };
        }

        /// <summary>
        /// 回傳失敗-訊息如引號內 「執行失敗: 找不到要執行動作的項目」。
        /// </summary>
        /// <returns>執行結果為失敗。</returns>
        public static PoResult DbNotFound()
        {
            return new PoResult { Message = "執行失敗: 找不到要執行動作的項目。" };
        }

        /// <summary>
        /// 回傳失敗-訊息如引號內 「執行失敗: <see cref="e.Message"/>」。
        /// </summary>
        /// <param name="e">要取得Message的Exception物件</param>
        /// <returns>執行結果為失敗。</returns>
        public static PoResult Exception(Exception e)
        {
            return new PoResult { Message = $"執行失敗: {e.Message}" };
        }

        /// <summary>
        /// 回傳失敗-訊息如引號內「資料庫錯誤」
        /// </summary>
        /// <returns>執行結果為失敗。</returns>
        public static PoResult DbException()
        {
            return new PoResult { Message = "資料庫錯誤" };
        }
        #endregion
    }


    /// <summary>
    /// 可裝載自訂物件的函式執行結果類別
    /// </summary>
    /// <typeparam name="T">Data的類型</typeparam>
    public class PoResult<T> : PoResult
    {
        /// <summary>
        /// 結果物件
        /// </summary>
        public T Data { get; set; }

        #region Static
        /// <summary>
        /// 回傳成功，沒有訊息，Data = <see cref="data"/>。
        /// </summary>
        /// <param name="data">Data物件類型</param>
        /// <returns>執行結果為成功。沒有Messge。Data為傳入的物件。</returns>
        public static PoResult<T> PoSuccess(T data)
        {
            return new PoResult<T> { Success = true, Data = data };
        }

        /// <summary>
        /// 回傳失敗，訊息如引號內 「<see cref="errorMsg"/>」
        /// </summary>
        /// <param name="errorMsg">錯誤訊息</param>
        /// <returns>執行結果為失敗。Data未指定。</returns>
        public static new PoResult<T> Fail(string errorMsg)
        {
            return new PoResult<T> { Success = false, Message = errorMsg };
        }

        /// <summary>
        /// 回傳失敗，訊息如引號內 「執行失敗: <see cref="errorMsg"/>」
        /// </summary>
        /// <param name="errorMsg">錯誤訊息，訊息的前端將會被加入「執行失敗: 」字樣</param>
        /// <returns>執行結果為失敗。Data未指定。</returns>
        public static new PoResult<T> MsgWithRunFail(string errorMsg)
        {
            return new PoResult<T> { Message = $"執行失敗: {errorMsg}" };
        }

        /// <summary>
        /// 回傳失敗-訊息如引號內 「執行失敗: 找不到要執行動作的項目」。
        /// </summary>
        /// <returns>執行結果為失敗。Data未指定。</returns>
        public static new PoResult<T> DbNotFound()
        {
            return new PoResult<T> { Message = "執行失敗: 找不到要執行動作的項目。" };
        }

        /// <summary>
        /// 回傳失敗-訊息如引號內 「執行失敗: <see cref="e.Message"/>」。
        /// </summary>
        /// <param name="e">要取得Message的Exception物件</param>
        /// <returns>執行結果為失敗。Data未指定。</returns>
        public static new PoResult<T> Exception(Exception e)
        {
            return new PoResult<T> { Message = $"執行失敗: {e.Message}" };
        }

        /// <summary>
        /// 回傳失敗-訊息如引號內「資料庫錯誤」
        /// </summary>
        /// <returns>執行結果為失敗。Data未指定。</returns>
        public static new PoResult<T> DbException()
        {
            return new PoResult<T> { Message = "資料庫錯誤" };
        }
        #endregion
    }
}
