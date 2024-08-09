namespace WebApplication1.DB
{
    public record Ctx
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class CtxDB
    {
        public static List<Ctx> _ctx1 = new List<Ctx>()
        {
            new Ctx{Id=1, Name="ctx"}
        };

        public static List<Ctx> GetCtxStatic()
        {
            return _ctx1;
        }

        public static Ctx CreateCtx(Ctx ctx)
        {
            _ctx1.Add(ctx);
            return ctx;
        }

        public static Ctx ? GetCtx(int id)
        {
            return _ctx1.SingleOrDefault(ctx => ctx.Id == id);
        }

        public static Ctx UpdateCtx(Ctx update)
        {
            _ctx1 = _ctx1.Select(ctx =>
            {
                if (ctx.Id == update.Id)
                {
                    ctx.Name = update.Name;
                }
                return ctx;
            }).ToList();
            return update;
        }


        public static void DeleteCtx(int id)
        {
            _ctx1 = _ctx1.FindAll(ctx => ctx.Id != id).ToList();
        }

    }
}
