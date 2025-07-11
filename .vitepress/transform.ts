import { PageData, SiteConfig } from "vitepress";

import { getWebsiteResolver } from "./i18n";

/**
 * Adds open graph data (social media embed info) and tells web crawlers to not index versioned pages.
 */
export function transformPageData(pageData: PageData, _context: any) {
  pageData.frontmatter.head ??= [];

  const parts = pageData.relativePath.split("/");
  const websiteTitle = getWebsiteResolver(
    parts[0][2] === "_" ? parts[0] : "root"
  )("title");
  const title =
    pageData.frontmatter.layout === "home"
      ? websiteTitle
      : pageData.title + " | " + websiteTitle;

  const tags = [
    ["theme-color", "#2275da"],

    // https://ogp.me/
    ["og:type", "website"],
    ["og:title", title],
    ["og:description", pageData.description],
    ["og:url", `https://javabridge.chiouya.cloud/${pageData.relativePath}`],
    ["og:image", "/logo.png"],
    ["og:locale", parts[0]],
    // TODO: "og:locale:alternate"?

    // https://developer.x.com/en/docs/twitter-for-websites/cards/guides/getting-started
    // haha still twitter
    ["twitter:card", "summary"],
    // TODO: "twitter:site"?
  ];

  // Don't index the page if it's a versioned page.
  if (pageData.filePath.includes("versions")) {
    tags.push(["robots", "noindex"]);
  }

  for (const tag of tags) {
    pageData.frontmatter.head.push([
      "meta",
      {
        property: tag[0],
        content: tag[1],
      },
    ]);
  }
}

export function transformItems(items: any[]): any[] {
  const config = globalThis.VITEPRESS_CONFIG as SiteConfig;
  const inverseRewrites = config.rewrites.inv;

  const itemsCopy = [...items];
  for (const item of items) {
    const path = item.url.replace("https://javabridge.chiouya.cloud/", "") + ".md";

    // Remove the item if it's a versioned item
    if (inverseRewrites[path]?.includes("versions")) {
      itemsCopy.splice(itemsCopy.indexOf(item), 1);
    }
  }

  return itemsCopy;
}
