
#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>

@interface UnityStoreKit : NSObject <SKProductsRequestDelegate, SKPaymentTransactionObserver>

@property (nonatomic, readwrite, copy) NSString *targetClass;
@property (nonatomic, readonly) SKProductsRequest *currentRequest;
@property (nonatomic, readonly) NSArray *products;

+ (instancetype) sharedUnityStoreKit;

- (void)sendMessage:(NSString *)methodName
           withData:(NSString *)data;

- (void)sendMessage:(NSString *)methodName;

- (BOOL)canMakePayments;

- (void)request:(NSSet *)products;

- (void)purchase:(NSString *)productIdentfifer;

- (void)restore;

@end
