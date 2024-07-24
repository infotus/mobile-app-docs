---
title: In App Purchase
weight: 3
---

# In App Purchase


The `PurchaseManager` class manages in-app purchases for a iOS application using the StoreKit framework. It provides functionalities to load available products, initiate purchases, and manage purchased product states.

### Class Declaration

```swift
@MainActor
class PurchaseManager: NSObject, ObservableObject
```

- Inherits from `NSObject` and conforms to `ObservableObject` to facilitate SwiftUI integration for observing changes in data.
- Annotated with `@MainActor` to ensure all operations are executed on the main thread, which is necessary for interacting with SwiftUI components.

### Properties

- `productsIds`: Array containing identifiers of in-app purchase products as defined in App Store Connect.
- `products`: Published array of `Product` objects representing the available in-app purchase items.
- `purchasedProductIds`: Set containing identifiers of purchased in-app products.
- `productsLoaded`: Boolean flag to track whether products have been loaded.
- `updates`: Optional `Task` to observe transaction updates asynchronously.

### Initialization

```swift
override init() {
    super.init()
    updates = observeTransactionUpdates()
    SKPaymentQueue.default().add(self)
}
```

- Initializes the `PurchaseManager`, sets up transaction observers (`SKPaymentTransactionObserver`), and starts observing transaction updates.

### Deinitialization

```swift
deinit {
    updates?.cancel()
}
```

- Cancels the `updates` task when the `PurchaseManager` is deallocated to clean up resources.

### Methods

1. **observeTransactionUpdates**
   - Observes transaction updates asynchronously.
   - Detects changes in transaction states and updates purchased product states accordingly.

2. **loadProducts**

   ```swift
   func loadProducts() async throws
   ```

   - Asynchronously loads available products from the App Store.
   - Sorts products by price for easier display.

3. **purchase**

   ```swift
   func purchase(_ product: Product) async throws -> Bool
   ```

   - Initiates a purchase for a specified `Product`.
   - Handles various purchase outcomes asynchronously:
     - Returns `true` if purchase is successfully verified and finished.
     - Returns `false` for pending, user cancelled, unverified, or unknown states.

4. **updatePurchasedProducts**

   ```swift
   func updatePurchasedProducts() async
   ```

   - Asynchronously updates the set of purchased product IDs based on transaction receipts.
   - Handles verification and revocation of purchased products.

#### Extensions

- **SKPaymentTransactionObserver**

  - Conformance to `SKPaymentTransactionObserver` protocol to receive transaction updates and handle payment queue events.

#### Usage

1. **Initialization**

   ```swift
   let purchaseManager = PurchaseManager()
   ```

   - Creates an instance of `PurchaseManager` to manage in-app purchases.

2. **Loading Products**

   ```swift
   do {
       try await purchaseManager.loadProducts()
   } catch {
       print("Failed to load products: \(error.localizedDescription)")
   }
   ```

   - Asynchronously loads products from the App Store.

3. **Purchasing Products**

   ```swift
   do {
       let success = try await purchaseManager.purchase(product)
       if success {
           // Handle successful purchase
       } else {
           // Handle failed purchase
       }
   } catch {
       // Handle purchase error
   }
   ```

   - Initiates a purchase for a specified product.


### Product Details

- **Products**: There are a total of 7 consumable products available for purchase.
- **Localization**: All products are localized in Japanese and Simplified Chinese.
- **Default Language**: The default language is English (U.S.).

#### Product List

1. **500 Cheer**
    - Price: 500 JPY

2. **1000 Cheer**
    - Price: 1000 JPY

3. **3000 Cheer**
    - Price: 3000 JPY

4. **5000 Cheer**
    - Price: 5000 JPY

5. **10000 Cheer**
    - Price: 10000 JPY

6. **30000 Cheer**
    - Price: 30000 JPY

7. **50000 Cheer**
    - Price: 50000 JPY


#### Currency Convertion

Prices are automatically converted for other regions based on the App Store's currency conversion rates.
