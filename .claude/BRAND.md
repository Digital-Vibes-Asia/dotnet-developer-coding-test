# Digital Vibes Asia — Brand Identity (canonical)

> Single source of truth, distilled from the official **"Digital Vibes Asia Brand CI 2023"** deck.
> When building or designing **anything** for DVA — apps, sites, decks, emails, assets — use these
> values. Do **not** invent colours or fonts, and do not substitute "close enough" alternatives.

## Colours

**Primary — DVA Red**
- `#CC1212` — CMYK 13/100/100/4 · Pantone P1788C. Primary brand colour: logo, CTAs, accents, active states.

**Secondary — Dark Cool Grey**
- `#0F181E` — CMYK 81/69/61/76 · Pantone P7547C. Primary dark surface / heading text.
- White `#FFFFFF`.

**Red scale** (tints — permitted for text, web, CTA buttons, digital)
| 900 | 800 (DVA Red) | 700 | 600 | 500 | 400 | 300 | 200 | 100 | 50 |
|---|---|---|---|---|---|---|---|---|---|
| `#BE0000` | `#CC1212` | `#D91D1A` | `#EA2B20` | `#F9371E` | `#F54A3F` | `#EC6D67` | `#F59692` | `#FFCBCE` | `#FFEAEC` |

**Cool Grey scale** (neutrals — surfaces, borders, body text). NB: cooler / blue-leaning — use this, **not** Tailwind `zinc`/`slate`.
| 900 (Dark Cool Grey) | 800 | 700 | 600 | 500 | 400 | 300 | 200 | 100 | 50 |
|---|---|---|---|---|---|---|---|---|---|
| `#0F181E` | `#2F383F` | `#4D565D` | `#606971` | `#879199` | `#A7B2BA` | `#CBD6DF` | `#DCE7F0` | `#E9F2FA` | `#EFFAFF` |

## Typography

Brand fonts (both free on Google Fonts):
- **Primary — Figtree.** Headlines = **Bold (700)**; sub-headers = **Medium (500)**.
- **Secondary — Montserrat.** Body / paragraphs / UI / web / decks = **Normal (400)**; emphasis = **Semibold (600)** / **Bold (700)**.

Rule from the CI: *"Do not use any other font, no matter how close it might look."* → not Inter, not system-ui as the brand face.

```
--font-heading: 'Figtree', sans-serif;   /* headings */
--font-body:    'Montserrat', sans-serif; /* everything else */
```
Figtree → https://fonts.google.com/specimen/Figtree · Montserrat → https://fonts.google.com/specimen/Montserrat

## Logo

- Two marks: **Primary Logomark** (full lockup) and **Logomark** (symbol only).
- Colourways: **Full Colour**, **One Colour (Dark Cool Grey `#0F181E`)**, **Monochrome (Black)**, **Reverse (White)** — pick for contrast against the background.
- **Clear space:** keep clear space equal to **50% of the logomark height** on every side (≈ the height of the "D"). Nothing intrudes.
- **Files:** PNG + vector in the brand Drive folder (`DVA-Logo-*` / `DVA-Logomark-*` in Red / Black / White / Cool-grey, plus a `vector/` folder). Prefer **SVG** on web/app.
- **Don'ts:** don't recolour · don't use another font · don't distort/stretch (scale in proportion only) · don't move or resize the mark within the lockup.

## Iconography
Medium line weight · **sharp (not rounded) corners** · brand colours only · simple, not busy · one consistent icon family per surface.

## Voice & usage
Corporate, consistent, high-contrast. Maintain strong contrast for accessibility (target WCAG AA+).

---

### ⚠️ Migration note (current apps drift from this CI)
The shipped DVA apps currently use **Inter + JetBrains Mono** and reds like `#E5343C` / the `#5b1a3a→#c0492f` gradient — **none of which are in the brand**. New and updated builds should adopt the canonical values above: **Figtree + Montserrat**, **DVA Red `#CC1212`**, and the **cool-grey** neutral scale. Drop `dva-brand.css` (next to this file) into any DVA project for ready-to-use tokens.
