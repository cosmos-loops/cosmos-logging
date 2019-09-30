

## cls.proto 说明

+ Log

| 字段 | 说明 |
|-----|------|
|Log.Content|内容|
|Log.time| Unix 格式时间戳|
|Log.contents|日志中的内容集合|

+ Log.Content

| 字段 | 说明 |
|-----|------|
|Log.Content.key|Key|
|Log.Content.value|Value|

+ LogGroup

| 字段 | 说明 |
|-----|------|
|logs| Log 多条日志合成的日志数组|
| contextFlow | 上下文唯一 ID，暂无效用|
|filename| 日志文件名|
|source|日志来源，一般使用机器编号（如机器IP）|

+ LogGroupList

| 字段 | 说明 |
|-----|------|
|logGroupList|日志组列表|