# Zero-Out Compression Algorithm (ZOCA)

ZOCA is a simple C# algorithm that compresses files by looking for pairs of 4 exact-same bytes in files, and condensing them into 3
bytes. This is especially effective in programs, as many programs have huge areas of repeated bytes (often hex 00, because it's
unused data). Therefore the effectiveness of the algorithm depends on the file itself. Every file can only be compressed so much
with this method.

At the current moment of time, the algorithm is not 100% reliable however.

# Flaws
(1) - If the original, uncompressed file contains "*4" (without quotes) anywhere, the compression will still work perfectly, but when it
comes to decompression, the decompressor will see the "*4" as 4 compressed bytes of the byte before the "*4", therefore producing 4 of that byte, instead of what it should be.

# Potential fixes
(1) - When compressing a file, a key should be generated that you give to the decompressor, which tells it where the compressed bytes are, and so, the decompressor makes sure that a "*4" is actually compressed bytes or if it's what the file is supposed to be without compression. This is partially implemented at the time of writing this, but the feature does not work and it still decompresses non-compressed bytes.
