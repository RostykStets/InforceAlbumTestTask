using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AuthorizedUsers",
                columns: new[] { "Id", "Login", "PasswordHash", "UserType" },
                values: new object[] { 1, "BabaYaga", "$2a$11$XphHfInZy0kPef.B0wePPuwspaJi7nA4hbTI6gtXxlyuzk.IXvLNq", 1 });

            migrationBuilder.InsertData(
                table: "AuthorizedUsers",
                columns: new[] { "Id", "Login", "PasswordHash", "UserType" },
                values: new object[] { 2, "MostCritical", "$2a$11$mOQU3uYcaLwPNCwIEjgqGeJILmLfzgXeB1565uHdu1fy.jXgbQk/q", 1 });
            
            migrationBuilder.InsertData(
                table: "AuthorizedUsers",
                columns: new[] { "Id", "Login", "PasswordHash", "UserType" },
                values: new object[] { 3, "David Goggins", "$2a$11$PfIfM1udIUZAoIsG8wSthej.1kjyVLwt1ir.xJDHFN4UvZrI0OQRS", 1 });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Login", "PasswordHash", "UserType" },
                values: new object[] { 1, "El Admino", "$2a$11$wUyli1DzFl3tzKsFWkQl5OTlSKMy5pyt44uqo5wkwkmnV7gnO9XvG", 0 });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 1, "Cubes", 1 });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 2, "Metal bands", 2 });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 3, "Nature of Ukraine", 3 });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 4, "European Architecture", 2 });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 5, "Modern Art", 3 });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 6, "Night Streets", 2 });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[] { 7, "Future Technology", 3 });


            // Adding images for "Cubes" album
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] {"Cube 3x3", "https://m.media-amazon.com/images/I/61tnRc8GrcL._AC_UF894,1000_QL80_.jpg", 5, 1, 1 });
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] {"Cube 9x9", "https://ukspeedcubes.co.uk/cdn/shop/files/QiYi9x9Maincopy.jpg?v=1697053400", 59, 18, 1 });
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] {"Cube 7x7", "https://m.media-amazon.com/images/I/61wTgnTNqNL._AC_UF894,1000_QL80_.jpg", 16, 5, 1 });

            // Adding images for "Metal bands" album
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Motionless In White", "https://images.squarespace-cdn.com/content/v1/5bb773e0fd67932c4bed9d3a/1560461471327-HGYLKZ67BULYLX5PIUX0/miw+band+promo.jpg?format=2500w", 70, 0, 2 });
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Imminence", "https://cdn-images.dzcdn.net/images/artist/3a31492b54620c72ff873190ccc1b17a/1900x1900-000000-80-0-0.jpg", 100, 0, 2 });
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Bring Me The Horizon", "https://images.sk-static.com/images/media/profile_images/artists/347077/huge_avatar", 50, 7, 2 });
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Lorna Shore", "https://lornashorestore.com/cdn/shop/files/LS_band6.jpg?v=1675375250&width=2400", 5, 1, 2 });
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "BAD OMENS", "https://www.musewiki.org/images/thumb/BadOmens.jpg/300px-BadOmens.jpg", 59, 18, 2 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Carpathian Mountains", "https://bukowina.org.ua/wp-content/uploads/2025/02/91951591.jpg", 45, 2, 3 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Synevyr Lake", "https://7chudes.in.ua/wp-content/uploads/2010/09/22829155.jpg", 67, 3, 3 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Dnister Canyon", "https://images.unsplash.com/photo-1595916549567-37cae207a044", 32, 1, 3 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Askania-Nova", "https://images.unsplash.com/photo-1557486123-a99acc983e14", 28, 0, 3 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Podilski Tovtry", "https://images.unsplash.com/photo-1513789181297-6f2ec112c0bc", 19, 2, 3 });

            // Adding images for "European Architecture" album
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Notre Dame Cathedral", "https://images.unsplash.com/photo-1549144511-f099e773c147", 89, 4, 4 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "St. Peter's Basilica", "https://images.unsplash.com/photo-1591003618710-fae8031756a4", 76, 1, 4 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Sagrada Familia", "https://images.unsplash.com/photo-1583864171077-bae1a0a5c24a", 95, 2, 4 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Colosseum", "https://images.unsplash.com/photo-1552832230-c0197dd311b5", 82, 3, 4 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Big Ben", "https://images.unsplash.com/photo-1500380804539-4e1e8c1e7118", 64, 2, 4 });

            // Adding images for "Modern Art" album
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "The Scream - Edvard Munch", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Edvard_Munch%2C_1893%2C_The_Scream%2C_oil%2C_tempera_and_pastel_on_cardboard%2C_91_x_73_cm%2C_National_Gallery_of_Norway.jpg/800px-Edvard_Munch%2C_1893%2C_The_Scream%2C_oil%2C_tempera_and_pastel_on_cardboard%2C_91_x_73_cm%2C_National_Gallery_of_Norway.jpg", 72, 8, 5 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Starry Night - Van Gogh", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg/1024px-Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg", 103, 5, 5 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Guernica - Picasso", "https://upload.wikimedia.org/wikipedia/en/7/74/PicassoGuernica.jpg", 65, 9, 5 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "The Persistence of Memory - Dali", "https://upload.wikimedia.org/wikipedia/en/d/dd/The_Persistence_of_Memory.jpg", 86, 7, 5 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Composition VIII - Kandinsky", "https://upload.wikimedia.org/wikipedia/commons/3/3a/Vassily_Kandinsky%2C_1923_-_Composition_8%2C_huile_sur_toile%2C_140_cm_x_201_cm%2C_Mus%C3%A9e_Guggenheim%2C_New_York.jpg", 54, 12, 5 });

            // Adding images for "Night Streets" album
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Tokyo at Night", "https://images.unsplash.com/photo-1540959733332-eab4deabeeaf", 92, 3, 6 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "New York After Rain", "https://images.unsplash.com/photo-1525373698358-041e3a460346", 78, 2, 6 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "London Night", "https://images.unsplash.com/photo-1513635269975-59663e0ac1ad", 63, 1, 6 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Hong Kong Lights", "https://images.unsplash.com/photo-1506154600429-a244e9305b8c", 81, 4, 6 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Paris Night", "https://images.unsplash.com/photo-1499856871958-5b9357976b82", 105, 2, 6 });


            // Adding images for "Future Technology" album
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Helper Robots", "https://images.unsplash.com/photo-1485827404703-89b55fcc595e", 71, 9, 7 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Smart Devices", "https://images.unsplash.com/photo-1520390138845-fd2d229dd553", 84, 7, 7 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Smart City", "https://images.unsplash.com/photo-1573164713988-8665fc963095", 68, 5, 7 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Virtual Reality", "https://images.unsplash.com/photo-1592478411213-6153e4ebc07d", 93, 4, 7 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Title", "ImageUrl", "LikeCounter", "DislikeCounter", "AlbumId" },
                values: new object[] { "Space Exploration Technology", "https://images.unsplash.com/photo-1446776811953-b23d57bd21aa", 79, 11, 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Images",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
