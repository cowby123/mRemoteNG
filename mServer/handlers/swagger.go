package handlers

import (
	"net/http"
	"os"

	"github.com/gin-gonic/gin"
)

// ServeSwaggerYAML 提供 Swagger YAML 文件
func ServeSwaggerYAML(c *gin.Context) {
	data, err := os.ReadFile("swagger.yaml")
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "無法讀取 Swagger 文件"})
		return
	}
	c.Data(http.StatusOK, "application/yaml", data)
}

// ServeSwaggerUI 提供 Swagger UI 頁面
func ServeSwaggerUI(c *gin.Context) {
	html := `<!DOCTYPE html>
<html lang="zh-TW">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>mRemoteNG Server API 文件</title>
    <link rel="stylesheet" href="https://unpkg.com/swagger-ui-dist@5.10.5/swagger-ui.css">
    <style>
        body {
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <div id="swagger-ui"></div>
    <script src="https://unpkg.com/swagger-ui-dist@5.10.5/swagger-ui-bundle.js"></script>
    <script src="https://unpkg.com/swagger-ui-dist@5.10.5/swagger-ui-standalone-preset.js"></script>
    <script>
        window.onload = function() {
            window.ui = SwaggerUIBundle({
                url: '/swagger.yaml',
                dom_id: '#swagger-ui',
                deepLinking: true,
                presets: [
                    SwaggerUIBundle.presets.apis,
                    SwaggerUIStandalonePreset
                ],
                layout: "StandaloneLayout"
            });
        };
    </script>
</body>
</html>`
	c.Data(http.StatusOK, "text/html; charset=utf-8", []byte(html))
}
