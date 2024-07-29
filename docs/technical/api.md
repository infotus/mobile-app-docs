---
title: API's
weight: 4
---
# API's Documentation

## AWS API's 

`APIService` provides a set of functions to interact with the Cheer Supports API, handling various routes related to user data, login, points, purchases, and more. Each function is asynchronous, using Swift's concurrency features for network operations.

### API Endpoints

#### Get User Avatar

- **Route:** `195`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/user/items?type=9`
- **Parameters:** 
  - `token` (String) - Bearer token for authentication

##### Request

```swift
func getUserAvatar(token: String) async throws -> String
```

##### Response

- **Success:** Returns the URL of the user’s avatar.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Unauthorized access
- `500..600`: Server errors
- `PathError.custom`: Custom error message if the response is not valid

#### Get User Profile Information

- **Route:** `129`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/user/channel/mine`
- **Parameters:**
  - `token` (String) - Bearer token for authentication

##### Request

```swift
func getUserProfile(token: String) async throws -> [Route129Response]
```

##### Response

- **Success:** Returns an array of `Route129Response` containing user profile information.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL or no data
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Login

- **Route:** `100`
- **Method:** `POST`
- **URL:** `https://api.cheer-supports.com/api/v1/liver/login`
- **Parameters:**
  - `email` (String)
  - `password` (String)

##### Request

```swift
func getLoginDatas(email: String, password: String, completion: @escaping (Result<Array<String>, AuthenticationError>) -> Void)
```

##### Response

- **Success:** Array containing user ID, nickname, and token.
- **Failure:** Throws `AuthenticationError` if login fails.

##### Error Handling

- `AuthenticationError.custom`: URL issues
- `AuthenticationError.invalidCredentials`: Invalid credentials or missing data

#### Check Current Points

- **Route:** `198`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/user/point?id={user_id}`
- **Parameters:**
  - `user_id` (String)
  - `token` (String)

##### Request

```swift
func checkCurrentPoint(user_id: String, token: String) async throws -> String
```

##### Response

- **Success:** Returns the user’s current points as a string.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Decrypt Purchase Key

- **Route:** `601`
- **Method:** `POST`
- **URL:** `https://api.cheer-supports.com/api/v1/app/purchase/key/decrypt?encodedkey={encoded_key}`
- **Parameters:**
  - `encoded_key` (String)
  - `token` (String)

##### Request

```swift
func sendEncodedData(encoded_key: String, token: String, completion: @escaping (Result<String, PurchaseError>) -> Void)
```

##### Response

- **Success:** Returns decrypted message.
- **Failure:** Throws `PurchaseError` for issues with the key or decoding.

##### Error Handling

- `PurchaseError.invalidUrl`: URL issues
- `PurchaseError.invalidKey`: Invalid key or decoding issues

#### Deduct Cheer

- **Route:** `602`
- **Method:** `POST`
- **URL:** `https://api.cheer-supports.com/api/v1/app/cheer/deduct`
- **Parameters:**
  - `user_id` (String)
  - `quantity` (Int)
  - `price` (Int)
  - `platform` (String)
  - `item_id` (String)
  - `token` (String)

##### Request

```swift
func sendCheerDeductionInformations(user_id: String, token: String, quantity: Int, price: Int, platform: String, item_id: String, completion: @escaping (Result<Route602Response, PathError>) -> Void)
```

##### Response

- **Success:** Returns `Route602Response` with deduction details.
- **Failure:** Throws `PathError` for issues with request or response.

##### Error Handling

- `PathError.custom`: URL issues
- `PathError.noData`: No data returned
- `PathError.decodingError`: Decoding issues

#### Delete Account Request

- **Route:** `132`
- **Method:** `POST`
- **URL:** `https://api.cheer-supports.com/api/v1/contact`
- **Parameters:**
  - `user_id` (String)
  - `token` (String)

##### Request

```swift
func deleteAccountRequest(user_id: String, token: String)
```

##### Response

- **Success:** No explicit response. Account deletion request is submitted.
- **Failure:** Logs error if URL is invalid.

##### Error Handling

- Logs error for invalid URL

#### Get Follow List Count

- **Route:** `196`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/liver/follow?user_id={user_id}`
- **Parameters:**
  - `user_id` (String)
  - `token` (String)

##### Request

```swift
func getFollowListCount(user_id: String, token: String) async throws -> Route196Response
```

##### Response

- **Success:** Returns `Route196Response` with follow list count.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Get Last Streaming Date

- **Route:** `603`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/channel/streaming/date/{user_id}`
- **Parameters:**
  - `user_id` (String)
  - `token` (String)

##### Request

```swift
func getLastStreaming(user_id: String, token: String) async throws -> Route603Response
```

##### Response

- **Success:** Returns `Route603Response` with last streaming date.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Get Watched Streams

- **Route:** `604`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/channel/watch/streaming/{user_id}`
- **Parameters:**
  - `user_id` (String)
  - `token` (String)

##### Request

```swift
func getWatchedStreams(user_id: String, token: String) async throws -> [Route604Response]
```

##### Response

- **Success:** Returns an array of `Route604Response` with watched streams.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

#### Get Last Gift Sent

- **Route:** `605`
- **Method:** `GET`
- **URL:** `https://api.cheer-supports.com/api/v1/yell/info/get/{user_id}`
- **Parameters:**
  - `user_id` (String)
  - `token` (String)

##### Request

```swift
func getLastGiftSend(user_id: String, token: String) async throws -> Route605Response
```

##### Response

- **Success:** Returns `Route605Response` with last gift sent details.
- **Failure:** Throws errors based on response status codes or data issues.

##### Error Handling

- `400..500`: Invalid URL
- `500..600`: Server errors
- `PathError.custom`: Custom error message for server issues

---

### Error Types

#### PathError

- `custom(errorMessage: String)`: Custom error with a message
- `noData`: No data received from the server
- `invalidUrl`: Invalid URL or endpoint
- `decodingError`: Error decoding the response

#### AuthenticationError

- `custom(errorMessage: String)`: Custom authentication error
- `invalidCredentials`: Invalid credentials provided

#### PurchaseError

- `invalidUrl`: Invalid URL for purchase decryption
- `invalidKey`: Invalid key provided
- `decoding_error`: Error decoding the decryption response
