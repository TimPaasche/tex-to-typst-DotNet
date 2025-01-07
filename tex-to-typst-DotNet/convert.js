import { texToTypst } from "tex-to-typst"; // Use `import` for ESM syntax

const latexContent = process.argv[2];

if (!latexContent) {
    console.error("Error: No LaTeX input provided.");
    process.exit(1); // Exit with an error code
}

try {
    const typstContent = texToTypst(latexContent);
    console.log(`TYPST=${typstContent.value}`);
} catch (error) {
    console.log(`LATEX=${latexContent}`);
}