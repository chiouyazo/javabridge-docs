---
title: Creating Your First Item
description: Learn how to register a simple item and how to texture, model and name it.
authors:
  - dicedpixels
  - Earthcomputer
  - IMB11
  - RaphProductions
  - chiouyazo
---

This page will introduce you into some key concepts relating to items, and how you can register, texture, model and name them.

If you aren't aware, everything in Minecraft is stored in registries, and items are no exception to that.
<!-- 
## Preparing Your Items Class {#preparing-your-items-class}

To simplify the registering of items, you can create a method that accepts a string identifier, some item settings and a factory to create the `Item` instance.

This method will create an item with the provided identifier and register it with the game's item registry.

You can put this method in a class called `ModItems` (or whatever you want to name the class).

Mojang does this with their items as well! Check out the `Items` class for inspiration.

@[code transcludeWith=:::1](@/reference/latest/src/main/java/com/example/docs/item/ModItems.java)

Notice the usage of a [`Function`](https://docs.oracle.com/en/java/javase/21/docs/api/java.base/java/util/function/Function.html) interface for the factory, which will later allow us to specify how we want our item to be created from the item settings using `Item::new`. -->

## Registering an Item {#registering-an-item}

To register an item, you will need to get the item handler from the bridge.

@[code transcludeWith=:::1](@/reference/latest/Csharp/example/ModItems.cs)

With which you can call the RegisterItem method, which takes in the item definition and item group.

@[code transcludeWith=:::2](@/reference/latest/Csharp/example/ModItems.cs)

The item definition is the key with which translations, and item models can be defined later.
It should be all lowercase.

The item group can be set to null, which makes the item not be registered to any group.


## Features to be added {#features-to-be-added}

* Item settings (e.g. item stack)
* Baked items
* Compostable/fuel ability
* Custom tooltips

<!-- You can now register an item using the method now. -->

<!-- The register method takes in an instance of the `Item.Settings` class as a parameter. This class allows you to configure the item's properties through various builder methods.

::: tip
If you want to change your item's stack size, you can use the `maxCount` method in the `Item.Settings` class.

This will not work if you've marked the item as damageable, as the stack size is always 1 for damageable items to prevent duplication exploits.
:::

@[code transcludeWith=:::2](@/reference/latest/src/main/java/com/example/docs/item/ModItems.java)

`Item::new` tells the register function to create an `Item` instance from an `Item.Settings` by calling the `Item` constructor (`new Item(...)`), which takes an `Item.Settings` as a parameter.

However, if you now try to run the modified client, you can see that our item doesn't exist in-game yet! This is because you didn't statically initialize the class.

To do this, you can add a public static initialize method to your class and call it from your [mod's initializer](../getting-started/project-structure#entrypoints) class. Currently, this method doesn't need anything inside it.

@[code transcludeWith=:::3](@/reference/latest/src/main/java/com/example/docs/item/ModItems.java)

@[code transcludeWith=:::1](@/reference/latest/src/main/java/com/example/docs/item/FabricDocsReferenceItems.java)

Calling a method on a class statically initializes it if it hasn't been previously loaded - this means that all `static` fields are evaluated. This is what this dummy `initialize` method is for. -->
<!-- 
## Adding the Item to an Item Group {#adding-the-item-to-an-item-group}

::: info
If you want to add the item to a custom `ItemGroup`, check out the [Custom Item Groups](./custom-item-groups) page for more information.
:::

For example purposes, we will add this item to the ingredients `ItemGroup`, you will need to use Fabric API's item group events - specifically `ItemGroupEvents.modifyEntriesEvent`

This can be done in the `initialize` method of your items class.

@[code transcludeWith=:::4](@/reference/latest/src/main/java/com/example/docs/item/ModItems.java)

Loading into the game, you can see that our item has been registered, and is in the Ingredients item group:

![Item in the ingredients group](/assets/develop/items/first_item_0.png)

However, it's missing the following:

- Item Model
- Texture
- Translation (name) -->

## Naming The Item {#naming-the-item}

The item currently doesn't have a translation, so you will need to add one. The translation key has already been provided by Minecraft: `item.mod_id.suspicious_substance`.

Create a new JSON file at: `src/main/resources/assets/mod-id/lang/en_us.json` and put in the translation key, and its value:

```json
{
  "item.mod_id.suspicious_substance": "Suspicious Substance"
}
```

You can either restart the game or build your mod and press <kbd>F3</kbd>+<kbd>T</kbd> to apply changes.

## Adding a Texture and Model {#adding-a-texture-and-model}

To give your item a texture and model, simply create a 16x16 texture image for your item and save it in the `assets/mod-id/textures/item` folder. Name the texture file the same as the item's identifier, but with a `.png` extension.

For example purposes, you can use this example texture for `suspicious_substance.png`

<DownloadEntry visualURL="/assets/develop/items/first_item_1.png" downloadURL="/assets/develop/items/first_item_1_small.png">Texture</DownloadEntry>

When restarting/reloading the game - you should see that the item still has no texture, that's because you will need to add a model that uses this texture.

You're going to create a simple `item/generated` model, which takes in an input texture and nothing else.

Create the model JSON in the `assets/mod-id/models/item` folder, with the same name as the item; `suspicious_substance.json`

@[code](@/reference/latest/src/main/generated/assets/fabric-docs-reference/models/item/suspicious_substance.json)

### Breaking Down the Model JSON {#breaking-down-the-model-json}

- `parent`: This is the parent model that this model will inherit from. In this case, it's the `item/generated` model.
- `textures`: This is where you define the textures for the model. The `layer0` key is the texture that the model will use.

Most items will use the `item/generated` model as their parent, as it's a simple model that just displays the texture.

There are alternatives, such as `item/handheld` which is used for items that are "held" in the player's hand, such as tools.

## Creating the Item Model Description {#creating-the-item-model-description}

Minecraft doesn't automatically know where your items' model files can be found, we need to provide an item model description.

Create the item description JSON in the `assets/mod-id/items`, with the same file name as the identifier of the item: `suspicious_substance.json`.

@[code](@/reference/latest/src/main/generated/assets/fabric-docs-reference/items/suspicious_substance.json)

### Breaking Down the Item Model Description JSON {#breaking-down-the-item-model-description-json}

- `model`: This is the property that contains the reference to our model.
  - `type`: This is the type of our model. For most items, this should be `minecraft:model`
  - `model`: This is the model's identifier. It should have this form: `mod-id:item/item_name`

Your item should now look like this in-game:

![Item with correct model](/assets/develop/items/first_item_2.png)

<!-- ## Making the Item Compostable or a Fuel {#making-the-item-compostable-or-a-fuel}

Fabric API provides various registries that can be used to add additional properties to your item.

For example, if you want to make your item compostable, you can use the `CompostableItemRegistry`:

@[code transcludeWith=:::_10](@/reference/latest/src/main/java/com/example/docs/item/ModItems.java)

Alternatively, if you want to make your item a fuel, you can use the `FuelRegistryEvents.BUILD` event:

@[code transcludeWith=:::_11](@/reference/latest/src/main/java/com/example/docs/item/ModItems.java) -->

## Adding a Basic Crafting Recipe {#adding-a-basic-crafting-recipe}

<!-- In the future, an entire section on recipes and recipe types should be created. For now, this suffices. -->

If you want to add a crafting recipe for your item, you will need to place a recipe JSON file in the `data/mod-id/recipe` folder.

For more information on the recipe format, check out these resources:

- [Recipe JSON Generator](https://crafting.thedestruc7i0n.ca/)
- [Minecraft Wiki - Recipe JSON](https://minecraft.wiki/w/Recipe#JSON_Format)

<!-- ## Custom Tooltips {#custom-tooltips}

If you want your item to have a custom tooltip, you will need to create a class that extends `Item` and override the `appendTooltip` method.

::: info
This example uses the `LightningStick` class created in the [Custom Item Interactions](./custom-item-interactions) page.
:::

@[code lang=java transcludeWith=:::3](@/reference/latest/src/main/java/com/example/docs/item/custom/LightningStick.java)

Each call to `add()` will add one line to the tooltip.

![Tooltip Showcase](/assets/develop/items/first_item_3.png) -->
