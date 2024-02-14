using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test435 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "5f919890-843d-4127-ade3-7eab5253e673");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78ab3cd1-93ea-45cd-8d97-d831ec396a87", "AQAAAAEAACcQAAAAEKLehiwIsmTPgnp4c1BmLL6VasdHiCPNbWwCkmL7VCFFjXw3QgO+f8/AMME6F5zwUA==", "d7bc2641-87b6-48c4-9b50-28d24d12b25d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eeed27a-8bbe-4fe7-9d9d-9f6779d18d21", "AQAAAAEAACcQAAAAEHwkKZIo6fCbAJSOFscqTYJjRrvmfFUyLkmpf0DOtb5chJXiYuqUsnLzTZVmikbfMw==", "aa24a204-efe3-4185-99e2-9709cefccad0" });

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndingCoordinatesId", "StartingCoordinatesId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 1, "UNE MECHANT GROS TRAJET", 2, null, null, "Bar chez Diane", "TestTrail", 1, 1, 0, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "0ddc2db3-7e01-45df-9b99-50fbcbd73139");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64ea326b-79c5-4975-9490-f3cf200cf6ec", "AQAAAAEAACcQAAAAEDdKtVkgt6vNQGFkroB6L5kk0l5k29ECZy9TVKn43zTIDzlgdiCGgyyjMcUm0Pw3tA==", "a2322085-223a-4a3c-930e-93eeea3fb468" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15629988-76b9-4045-96b7-f11daa1f85e4", "AQAAAAEAACcQAAAAEMvLsGmNN0ocD3gTrLVqiAPuaxA+rMG7K+rp9Qncntibi2aR/vX1AqBpgjj2HXMJ5Q==", "686bc392-1dbe-45aa-8322-a394b5765815" });

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndingCoordinatesId", "StartingCoordinatesId" },
                values: new object[] { 4, 3 });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 4, "Une promenade facile le long de ruisseaux pittoresques et de cascades rafraîchissantes, idéal pour toute la famille.", 6, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAO_hEyiI2Tkfl5TI78QWQpncjBZ_7VWxtU4rceThJXeSRAKCutUx62Hfw5sdbX_QBEa4&usqp=CAU", null, "Parc Naturel des Chutes d'Eau", "Chemin des Cascades", 1, 5, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 5, "Un sentier sinueux à travers une vallée verdoyante parsemée de fleurs sauvages et offrant des vues spectaculaires sur les montagnes environnantes.", 8, "https://i.pinimg.com/originals/7f/e4/e2/7fe4e24eb9024d61139ac44a607e478a.jpg", null, "Parc National de la Vallée Florissante", "Randonnée de la Vallée Verdoyante", 1, 7, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 6, "Une agréable balade autour d'un lac paisible, idéale pour observer la faune locale et profiter d'un moment de calme.", 10, "https://californiathroughmylens.com/wp-content/uploads/2019/05/crystal-cove-el-moro-12-640x427.jpg", null, "Réserve Naturelle du Lac Serein", "Boucle du Lac Tranquille", 1, 9, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 7, "Une randonnée modérée à travers les collines ondulantes offrant des panoramas magnifiques sur la campagne environnante.", 12, "https://blog.ab.bluecross.ca/wp-content/uploads/2020/08/fav-hikes-part-three.jpg", null, "Parc Naturel des Collines Verdoyantes", "Sentier des Collines", 1, 11, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 8, "Une promenade relaxante le long d'une rivière tranquille, où vous pourrez vous détendre au son de l'eau qui coule et observer la vie sauvage.", 14, "https://www.travelandleisure.com/thmb/9TgvQ-g-uFDD4IwbBzlZ8eeEZs8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/george-s-mickelson-trail-south-dakota_RAILTRAIL0123-f3e27d5d1e2f44efb8bf368185d74130.jpg", null, "Parc Naturel de la Rivière Sereine", "Parcours de la Rivière Paisible", 1, 13, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 9, "Une courte randonnée menant à une cascade scintillante, où vous pourrez vous rafraîchir et prendre de superbes photos.", 16, "https://www.nps.gov/hosp/planyourvisit/images/_DSC7261.jpg?maxwidth=650&autorotate=false", null, "Parc Naturel de la Cascade d'Argent", "Chemin de la Cascade d'Argent", 1, 15, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 10, "Une randonnée épique menant au sommet des montagnes les plus élevées, offrant des vues à couper le souffle sur les vallées et les sommets environnants.", 18, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUGLsH09jYtknRspMu0BDdOsADZrSLhzBUtA&usqp=CAU", null, "Parc National des Hautes Montagnes", "Randonnée des Cimes", 1, 17, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 11, "Une agréable promenade à travers une forêt de chênes majestueux, où vous pourrez admirer la beauté de la nature et observer la faune locale.", 20, "https://www.surrey.ca/sites/default/files/styles/metatag_facebook/public/2020-08/InvergarryNatureTrail.JPG?h=d262251e&itok=oXPbDLYW", null, "Réserve Naturelle des Chênes Rouges", "Sentier des Chênes Rouges", 1, 19, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 12, "Une balade tranquille autour d'un lac miroir, où le reflet des montagnes crée une atmosphère magique.", 22, "https://i.natgeofe.com/n/71741e7e-db92-41fc-9c54-f781c3df87df/2C57A8C_16x9.jpg", null, "Parc Naturel du Lac Miroir", "Parcours du Lac Miroir", 1, 21, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 13, "Une randonnée agréable le long d'une rivière sinueuse, où vous pourrez apercevoir des loutres jouant dans l'eau cristalline.", 24, "https://www.mississauga.ca/wp-content/uploads/2022/10/14143203/20221010_115918-scaled.jpg", null, "Réserve Naturelle des Loutres", "Boucle des Loutres", 1, 23, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 14, "Une randonnée spectaculaire le long de falaises escarpées offrant des vues à couper le souffle sur l'océan et les îles lointaines.", 26, "https://i.cbc.ca/1.4170049.1530218327!/fileImage/httpImage/hiking-trails.jpg", null, "Réserve Naturelle des Falaises", "Parcours des Falaises", 1, 25, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 15, "Une randonnée exigeante menant au sommet d'un pic enneigé, offrant des vues panoramiques sur les montagnes enneigées à perte de vue.", 28, "https://www.lethbridge.ca/media/4bsdermr/pavan-trail.jpg", null, "Parc National des Pics Enneigés", "Randonnée du Pic Enneigé", 1, 27, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 16, "Une agréable balade le long d'une rivière sinueuse, où vous pourrez observer une grande variété d'oiseaux et de poissons.", 30, "https://www.travelandleisure.com/thmb/9TgvQ-g-uFDD4IwbBzlZ8eeEZs8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/george-s-mickelson-trail-south-dakota_RAILTRAIL0123-f3e27d5d1e2f44efb8bf368185d74130.jpg", null, "Parc Naturel de la Rivière Serpentine", "Parcours de la Rivière Serpentine", 1, 29, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 17, "Une randonnée matinale menant à un point de vue idéal pour observer le lever du soleil sur les montagnes environnantes.", 32, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUGLsH09jYtknRspMu0BDdOsADZrSLhzBUtA&usqp=CAU", null, "Parc National du Lever du Soleil", "Randonnée du Lever du Soleil", 1, 31, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 18, "Une balade tranquille à travers une clairière ensoleillée, où vous pourrez observer une grande variété de fleurs sauvages et d'insectes.", 34, "https://www.travelandleisure.com/thmb/9TgvQ-g-uFDD4IwbBzlZ8eeEZs8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/george-s-mickelson-trail-south-dakota_RAILTRAIL0123-f3e27d5d1e2f44efb8bf368185d74130.jpg", null, "Réserve Naturelle de la Clairière", "Chemin de la Clairière", 1, 33, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 19, "Une randonnée jusqu'à un rocher solitaire offrant une vue panoramique sur la vallée et les montagnes environnantes.", 36, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAO_hEyiI2Tkfl5TI78QWQpncjBZ_7VWxtU4rceThJXeSRAKCutUx62Hfw5sdbX_QBEa4&usqp=CAU", null, "Réserve Naturelle du Rocher Solitaire", "Randonnée du Rocher Solitaire", 1, 35, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 20, "Une agréable promenade à travers un verger de pommiers en fleurs, où vous pourrez profiter du parfum délicat des fleurs et observer les abeilles qui butinent.", 38, "https://i.pinimg.com/originals/7f/e4/e2/7fe4e24eb9024d61139ac44a607e478a.jpg", null, "Verger des Pommiers", "Promenade des Pommiers", 1, 37, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 21, "Une randonnée menant à de magnifiques chutes d'eau cristalline, où vous pourrez vous rafraîchir et vous ressourcer en pleine nature.", 40, "https://blog.ab.bluecross.ca/wp-content/uploads/2020/08/fav-hikes-part-three.jpg", null, "Réserve Naturelle des Chutes de Cristal", "Sentier des Chutes de Cristal", 1, 39, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 22, "Une promenade relaxante le long des rives d'un lac serein, où vous pourrez observer les reflets du ciel et des montagnes sur l'eau calme.", 42, "https://www.nps.gov/hosp/planyourvisit/images/_DSC7261.jpg?maxwidth=650&autorotate=false", null, "Parc Naturel du Lac Serein", "Parcours du Lac Serein", 1, 41, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 23, "Une randonnée à travers les collines verdoyantes, où vous pourrez admirer les vues panoramiques sur la campagne environnante.", 44, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUGLsH09jYtknRspMu0BDdOsADZrSLhzBUtA&usqp=CAU", null, "Réserve Naturelle des Collines Verdoyantes", "Randonnée des Collines Verdoyantes", 1, 43, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 24, "Une promenade menant à une cascade scintillante, où les rayons du soleil dansent sur l'eau en créant des arcs-en-ciel éphémères.", 46, "https://www.surrey.ca/sites/default/files/styles/metatag_facebook/public/2020-08/InvergarryNatureTrail.JPG?h=d262251e&itok=oXPbDLYW", null, "Réserve Naturelle de la Cascade Scintillante", "Sentier de la Cascade Scintillante", 1, 45, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 25, "Une boucle le long d'une rivière tranquille, où vous pourrez observer la faune et la flore locales tout en écoutant le doux murmure de l'eau.", 48, "https://i.natgeofe.com/n/71741e7e-db92-41fc-9c54-f781c3df87df/2C57A8C_16x9.jpg", null, "Réserve Naturelle de la Rivière Tranquille", "Boucle de la Rivière Tranquille", 1, 47, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 26, "Une randonnée exigeante menant au sommet d'un pic enneigé, offrant des vues panoramiques sur les montagnes enneigées à perte de vue.", 50, "https://www.lethbridge.ca/media/4bsdermr/pavan-trail.jpg", null, "Parc National des Pics Enneigés", "Randonnée du Pic Enneigé", 1, 49, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 27, "Une agréable balade le long d'une rivière sinueuse, où vous pourrez observer une grande variété d'oiseaux et de poissons.", 52, "https://www.travelandleisure.com/thmb/9TgvQ-g-uFDD4IwbBzlZ8eeEZs8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/george-s-mickelson-trail-south-dakota_RAILTRAIL0123-f3e27d5d1e2f44efb8bf368185d74130.jpg", null, "Parc Naturel de la Rivière Serpentine", "Parcours de la Rivière Serpentine", 1, 51, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 28, "Une randonnée matinale menant à un point de vue idéal pour observer le lever du soleil sur les montagnes environnantes.", 54, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUGLsH09jYtknRspMu0BDdOsADZrSLhzBUtA&usqp=CAU", null, "Parc National du Lever du Soleil", "Randonnée du Lever du Soleil", 1, 53, 0, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 29, "Une balade tranquille à travers une clairière ensoleillée, où vous pourrez observer une grande variété de fleurs sauvages et d'insectes.", 56, "https://www.travelandleisure.com/thmb/9TgvQ-g-uFDD4IwbBzlZ8eeEZs8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/george-s-mickelson-trail-south-dakota_RAILTRAIL0123-f3e27d5d1e2f44efb8bf368185d74130.jpg", null, "Réserve Naturelle de la Clairière", "Chemin de la Clairière", 1, 55, 1, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "isPublic" },
                values: new object[] { 30, "Une randonnée à travers un paysage de rochers sculptés par le temps, où vous pourrez découvrir des formations rocheuses fascinantes.", 58, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAO_hEyiI2Tkfl5TI78QWQpncjBZ_7VWxtU4rceThJXeSRAKCutUx62Hfw5sdbX_QBEa4&usqp=CAU", null, "Réserve Naturelle des Rochers Ciselés", "Randonnée des Rochers Ciselés", 1, 57, 1, false });
        }
    }
}
