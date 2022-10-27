#include <GLFW/glfw3.h>
#include <mupdf/fitz.h>
#define DFILENAME 

int main()
{
    float zoom = 100, rotate=0;
    int page_number = 0, page_count;
    fz_context* ctx = fz_new_context(NULL, NULL, FZ_STORE_DEFAULT);
    fz_document* doc;
    fz_pixmap* pix;
    fz_matrix ctm;
    int x, y;

    if (!ctx) { // Eğer ctx oluşturulamadıysa
        fprintf(stderr, "cannot create mupdf context\n");
        return EXIT_FAILURE;
    }

    fz_try(ctx)
        fz_register_document_handlers(ctx);
    fz_catch(ctx)
    {
        fprintf(stderr, "cannot register document handlers: %s\n", fz_caught_message(ctx));
        fz_drop_context(ctx);
        return EXIT_FAILURE;
    }

    fz_try(ctx)
        doc = fz_open_document(ctx, "C:\\Users\\musta\\yabanci_seyahatnamelere_gore_osmanlida_hayvan.pdf");
    fz_catch(ctx)
    {
        fprintf(stderr, "cannot open document: %s\n", fz_caught_message(ctx));
        fz_drop_context(ctx);
        return EXIT_FAILURE;
    }

    fz_try(ctx)
        page_count = fz_count_pages(ctx, doc);
    fz_catch(ctx)
    {
        fprintf(stderr, "cannot count number of pages: %s\n", fz_caught_message(ctx));
        fz_drop_document(ctx, doc);
        fz_drop_context(ctx);
        return EXIT_FAILURE;
    }

    ctm = fz_scale(zoom / 100, zoom / 100);

    fz_try(ctx)
        pix = fz_new_pixmap_from_page_number(ctx, doc, page_number, ctm, fz_device_rgb(ctx), 0);
    fz_catch(ctx)
    {
        fprintf(stderr, "cannot render page: %s\n", fz_caught_message(ctx));
        fz_drop_document(ctx, doc);
        fz_drop_context(ctx);
        return EXIT_FAILURE;
    }
    
    

    /* Clean up. */
    fz_drop_pixmap(ctx, pix);
    fz_drop_document(ctx, doc);

    GLFWwindow* window;

    if (!glfwInit())
        return -1;

    window = glfwCreateWindow(1920, 1080, "Okul Belge Goruntuleyici", NULL, NULL);
    if (!window)
    {
        glfwTerminate();
        return -1;
    }

    glfwMakeContextCurrent(window);

    while (!glfwWindowShouldClose(window))
    {
        glClear(GL_COLOR_BUFFER_BIT);

        glfwSwapBuffers(window);

        glfwPollEvents();

        glDrawPixels(pix->w, pix->h, GL_RGB, GL_UNSIGNED_BYTE, &pix->samples);
    }

    glfwTerminate();
    fz_drop_context(ctx);
    return 0;
}