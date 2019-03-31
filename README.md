# Zero-Out Compression Algorithm (ZOCA)

ZOCA is a simple C# algorithm that compresses files by looking for pairs of 4 exact-same bytes in files, and condensing them into 3
bytes. This is especially effective in programs, as many programs have huge areas of repeated bytes (often hex 00, because it's
unused data). Therefore the effectiveness of the algorithm depends on the file itself. Every file can only be compressed so much
with this method.

