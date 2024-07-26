---
title: Notification Model
weight: 4
---

# Access Token Model

This script defines structures and constants for managing Google API access tokens and service account details in a Swift application. It uses Firebase Firestore for storing and retrieving this data. The script includes constants for API access and service account fields, as well as data models for encoding, decoding, and managing this information.


### **GoogleAPIAccessConstants**

```swift
struct GoogleAPIAccessConstants {
    static let expired = "expired_time"
    static let accessToken = "token"
    static let updated_by = "updated_uuid"
    static let access_uid = "Access_Token"
    static let service_uid = "Service_Account"
    static let json = "json"
}
```

**Purpose**: Defines constants for field names related to Google API access tokens. These constants are used to avoid hardcoding field names in the application and ensure consistency.

- `expired`: The field name for the expiration time of the token.
- `accessToken`: The field name for the access token itself.
- `updated_by`: The field name for the UUID of the user who last updated the token.
- `access_uid`: The field name for the access token identifier.
- `service_uid`: The field name for the service account identifier.
- `json`: The field name for JSON data associated with the token or service account.

### **AccessTokenData**

```swift
struct AccessTokenData {
    let expired: Date
    let token: String
    let updated_by: String
    
    init(expired: Date, token: String, updated_by: String) {
        self.expired = expired
        self.token = token
        self.updated_by = updated_by
    }
}
```

**Purpose**: Represents the data associated with an access token, including its expiration time, the token value, and the UUID of the user who updated it.

- `expired`: The expiration date of the access token.
- `token`: The access token value.
- `updated_by`: UUID of the user who last updated the token.


### **AccessTokenModel**

```swift
struct AccessTokenModel: Codable, Identifiable, Hashable {
    @DocumentID var id: String?

    var expired: Date
    var token: String
    var updated_by: String

    enum CodingKeys: CodingKey {
        case id
        case expired
        case token
        case updated_by
    }
}
```

**Purpose**: A data model used for encoding and decoding access token information with Firestore. It conforms to `Codable`, `Identifiable`, and `Hashable` protocols for easy integration with Firestore.

- `id`: Optional unique identifier for the Firestore document.
- `expired`: The expiration date of the access token.
- `token`: The access token value.
- `updated_by`: UUID of the user who last updated the token.

- **CodingKeys Enum**: Maps Swift property names to Firestore field names to facilitate encoding and decoding.



### **ServiceAccountConstants**

```swift
struct ServiceAccountConstants {
    static let type = "type"
    static let project_id = "project_id"
    static let private_key_id = "private_key_id"
    static let private_key = "private_key"
    static let client_email = "client_email"
    static let client_id = "client_id"
    static let auth_uri = "auth_uri"
    static let token_uri = "token_uri"
    static let auth_provider = "auth_provider_x509_cert_url"
    static let client_cert_url = "client_x509_cert_url"
    static let universe_domain = "universe_domain"
}
```

**Purpose**: Defines constants for field names related to service account credentials. These constants are used to maintain consistency and avoid hardcoding field names.

- `type`: The type of the service account.
- `project_id`: The project ID associated with the service account.
- `private_key_id`: The ID of the private key.
- `private_key`: The private key itself.
- `client_email`: The email address associated with the service account.
- `client_id`: The client ID.
- `auth_uri`: The authentication URI.
- `token_uri`: The token URI for obtaining access tokens.
- `auth_provider`: The URL for the authentication provider's certificate.
- `client_cert_url`: The URL for the client certificate.
- `universe_domain`: The universe domain associated with the service account.

### **ServiceAccountData**

```swift
struct ServiceAccountData {
    let type: String
    let project_id: String
    let private_key_id: String
    let private_key: String
    let client_email: String
    let client_id: String
    let auth_uri: String
    let token_uri: String
    let auth_provider: String
    let client_cert_url: String
    let universe_domain: String
    
    init(type: String, project_id: String, private_key_id: String, private_key: String, client_email: String, client_id: String, auth_uri: String, token_uri: String, auth_provider: String, client_cert_url: String, universe_domain: String) {
        self.type = type
        self.project_id = project_id
        self.private_key_id = private_key_id
        self.private_key = private_key
        self.client_email = client_email
        self.client_id = client_id
        self.auth_uri = auth_uri
        self.token_uri = token_uri
        self.auth_provider = auth_provider
        self.client_cert_url = client_cert_url
        self.universe_domain = universe_domain
    }
}
```

**Purpose**: Represents the data associated with a service account. This structure is used to manage and initialize service account details.

- `type`: The type of the service account.
- `project_id`: The project ID associated with the service account.
- `private_key_id`: The ID of the private key.
- `private_key`: The private key itself.
- `client_email`: The email address associated with the service account.
- `client_id`: The client ID.
- `auth_uri`: The authentication URI.
- `token_uri`: The token URI for obtaining access tokens.
- `auth_provider`: The URL for the authentication provider's certificate.
- `client_cert_url`: The URL for the client certificate.
- `universe_domain`: The universe domain associated with the service account.

### **ServiceAccountModel**

**NOTE: Currently is unused model therefore can be ignore it.**

```swift
struct ServiceAccountModel: Codable, Identifiable, Hashable {
    @DocumentID var id: String?
    
    var type: String
    var project_id: String
    var private_key_id: String
    var private_key: String
    var client_email: String
    var client_id: String
    var auth_uri: String
    var token_uri: String
    var auth_provider: String
    var client_cert_url: String
    var universe_domain: String
    
    enum CodingKeys: CodingKey {
        case type
        case project_id
        case private_key_id
        case private_key
        case client_email
        case client_id
        case auth_uri
        case token_uri
        case auth_provider
        case client_cert_url
        case universe_domain
    }
}
```

**Purpose**: A data model used for encoding and decoding service account information with Firestore. It conforms to `Codable`, `Identifiable`, and `Hashable` protocols for easy integration with Firestore.

- `id`: Optional unique identifier for the Firestore document.
- `type`: The type of the service account.
- `project_id`: The project ID associated with the service account.
- `private_key_id`: The ID of the private key.
- `private_key`: The private key itself.
- `client_email`: The email address associated with the service account.
- `client_id`: The client ID.
- `auth_uri`: The authentication URI.
- `token_uri`: The token URI for obtaining access tokens.
- `auth_provider`: The URL for the authentication provider's certificate.
- `client_cert_url`: The URL for the client certificate.
- `universe_domain`: The universe domain associated with the service account.



- **CodingKeys Enum**: Maps Swift property names to Firestore field names to facilitate encoding and decoding.


The script provides a structured approach to managing Google API access tokens and service account details within a Swift application. It includes:

- **`GoogleAPIAccessConstants`**: Constants for field names related to Google API access tokens.
- **`AccessTokenData`**: Represents access token data with an initializer.
- **`AccessTokenModel`**: A Firestore-compatible model for access token data.
- **`ServiceAccountConstants`**: Constants for field names related to service account credentials.
- **`ServiceAccountData`**: Represents service account data with an initializer.
- **`ServiceAccountModel`**: A Firestore-compatible model for service account data.
