magick convert -background none -define icon:auto-resize="32,16" favicon.svg favicon.ico
magick mogrify  -trim favicon.ico

magick convert -background none -resize 192x192 favicon.svg favicon-192.png

magick mogrify  -trim favicon-192.png