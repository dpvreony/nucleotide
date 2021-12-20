# Add your introductions here!

```@plantuml
 classDiagram
      EntityFrameworkModel --|> KeyedModel
      KeyedModel ..|> IKeyedModel
      KeyedModel --|> UnkeyedModel
      UnkeyedModel ..|> IUnkeyedModel
      IKeyedModel ..|> IId~TId~
      IKeyedModel ..|> IModified
      IModified ..|> ICreated
      class EntityFrameworkModel{
          +long RowVersion
      }
      class IKeyedModel{
          <<interface>>
      }
      class UnkeyedModel{
      }
      class IUnkeyedModel{
          <<interface>>
      }
      class ICreated{
          <<interface>>
          +DateTimeOffset? Created
      }
      class IModified{
          <<interface>>
          +DateTimeOffset? Modified
      }
      class IId~TId~ {
          <<interface>>
          +~TId~ Id
      }
```