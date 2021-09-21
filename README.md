# PromotionEngine

Please note that this solution was built using Visual Studio MAC.

Few pointers for next iteration of code changes.

- Hybird coupons logic was added to only static scenario. The logic needs to be extended for dynamic scenarios with different permutations and combinations.
- Code clean up to removed classes that are not needed.
- Introduce interfaces so dependency injection could be leveraged. Right now, objects are instantiated directly.
- Introduce unit test framework.

# Updates

- Added new class library project and separated all classes from main executable.
- Added unit tests.
