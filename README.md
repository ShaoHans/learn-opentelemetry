### Tempo部署参考官方文档
https://github.com/grafana/tempo/blob/main/example/docker-compose/otel-collector/docker-compose.yaml



### Grafana面板添加Metrics数据源
 <p>连接 → 数据源 → 添加数据源 → 选择prometheus</p>
 <p>注意：如果通过docker compose部署的，Url可能要配置为：http://prometheus:3200</p>

### Grafana面板添加Logs数据源
 <p>连接 → 数据源 → 添加数据源 → 选择loki</p>
 <p>注意：如果通过docker compose部署的，Url可能要配置为：http://loki:3200</p>

### Grafana面板添加Traces数据源
 <p>连接 → 数据源 → 添加数据源 → 选择tempo</p>
 <p>注意：如果通过docker compose部署的，Url可能要配置为：http://tempo:3200</p>
