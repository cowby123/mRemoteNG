package models

// JSendResponse JSend 規範的統一回應格式
type JSendResponse struct {
	Status  string      `json:"status"`            // success, fail, error
	Data    interface{} `json:"data,omitempty"`    // 成功時的資料
	Message string      `json:"message,omitempty"` // fail/error 時的訊息
	Code    int         `json:"code,omitempty"`    // 可選的錯誤碼
}

// NewSuccessResponse 建立成功回應
func NewSuccessResponse(data interface{}) JSendResponse {
	return JSendResponse{
		Status: "success",
		Data:   data,
	}
}

// NewFailResponse 建立失敗回應（客戶端錯誤）
func NewFailResponse(message string) JSendResponse {
	return JSendResponse{
		Status:  "fail",
		Message: message,
	}
}

// NewErrorResponse 建立錯誤回應（伺服器錯誤）
func NewErrorResponse(message string, code int) JSendResponse {
	return JSendResponse{
		Status:  "error",
		Message: message,
		Code:    code,
	}
}
